using Final_Project.DataAccessLayer;
using Final_Project.Models;
using Final_Project.ViewModels.CartItemViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Final_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly DannyDbContext _context;
        private readonly IValidator<CartItemCreateVM> _validator;

        public CartController(DannyDbContext context, IValidator<CartItemCreateVM> validator)
        {
            _context = context;
            _validator = validator;
        }

        // Helper method userId almaq üçün
        private string? GetUserId()
        {
            return User.Identity?.IsAuthenticated == true
                ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                : null;
        }

    
        public IActionResult Index()
        {
            var userId = GetUserId();

            List<CartItem> cartItems;
            if (userId != null)
            {
                cartItems = _context.CartItems
                    .Include(c => c.Food)
                    .Where(c => c.UserId == userId)
                    .ToList();
            }
            else
            {
                var sessionId = HttpContext.Session.GetString("SessionId");
                if (string.IsNullOrEmpty(sessionId))
                {
                    sessionId = Guid.NewGuid().ToString();
                    HttpContext.Session.SetString("SessionId", sessionId);
                }

                cartItems = _context.CartItems
                    .Include(c => c.Food)
                    .Where(c => c.SessionId == sessionId)
                    .ToList();
            }

            return View(cartItems);
        }

      
        [HttpPost]
        public async Task<IActionResult> Add(CartItemCreateVM model)
        {
            var validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            var userId = GetUserId();

            if (userId != null)
            {
                var existingItem = _context.CartItems.FirstOrDefault(c => c.FoodId == model.FoodId && c.UserId == userId);
                if (existingItem != null)
                {
                    existingItem.Quantity += model.Quantity;
                }
                else
                {
                    _context.CartItems.Add(new CartItem
                    {
                        FoodId = model.FoodId,
                        Quantity = model.Quantity,
                        UserId = userId
                    });
                }
            }
            else
            {
                var sessionId = HttpContext.Session.GetString("SessionId");
                if (string.IsNullOrEmpty(sessionId))
                {
                    sessionId = Guid.NewGuid().ToString();
                    HttpContext.Session.SetString("SessionId", sessionId);
                }

                var existingItem = _context.CartItems.FirstOrDefault(c => c.FoodId == model.FoodId && c.SessionId == sessionId);
                if (existingItem != null)
                {
                    existingItem.Quantity += model.Quantity;
                }
                else
                {
                    _context.CartItems.Add(new CartItem
                    {
                        FoodId = model.FoodId,
                        Quantity = model.Quantity,
                        SessionId = sessionId
                    });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item == null) return NotFound();

            var userId = GetUserId();
            if (userId != null && item.UserId != userId)
                return Forbid();

            var sessionId = HttpContext.Session.GetString("SessionId");
            if (userId == null && item.SessionId != sessionId)
                return Forbid();

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }


}
