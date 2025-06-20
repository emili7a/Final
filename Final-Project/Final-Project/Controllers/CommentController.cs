using Final_Project.DataAccessLayer;
using Final_Project.Models;
using Final_Project.ViewModels.CommentViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class CommentController : Controller
    {
        private readonly DannyDbContext _context;
        private readonly IValidator<CommentCreateVM> _validator;

        public CommentController(DannyDbContext context, IValidator<CommentCreateVM> validator)
        {
            _context = context;
            _validator = validator;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateVM model)
        {
            var result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                return RedirectToAction("Details", "Food", new { id = model.FoodId });
            }

            var comment = new Comment
            {
                FoodId = model.FoodId,
                UserName = model.UserName,
                Message = model.Message,
                Rating = model.Rating,
                CreatedAt = DateTime.Now,
                IsApproved = false 
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Your comment has been submitted and is awaiting approval.";
            return RedirectToAction("Details", "Food", new { id = model.FoodId });
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var comments = _context.Comments
                .Include(c => c.Food)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CommentAdminVM
                {
                    Id = c.Id,
                    FoodName = c.Food.Name,
                    UserName = c.UserName,
                    Message = c.Message,
                    Rating = c.Rating,
                    CreatedAt = c.CreatedAt,
                    IsApproved = c.IsApproved
                }).ToList();

            return View(comments);
        }

       
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return NotFound();

            comment.IsApproved = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return NotFound();

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }


}
