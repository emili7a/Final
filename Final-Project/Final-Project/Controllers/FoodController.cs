using Final_Project.DataAccessLayer;
using Final_Project.Models;
using Final_Project.ViewModels.FoodViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class FoodController : Controller
    {
        private readonly DannyDbContext _context;
        private readonly IValidator<FoodCreateVM> _validator;

        public FoodController(DannyDbContext context, IValidator<FoodCreateVM> validator)
        {
            _context = context;
            _validator = validator;
        }

        
        public IActionResult Index()
        {
            var foods = _context.Foods
                .Include(f => f.Category)
                .Include(f => f.FoodIngredients)
                    .ThenInclude(fi => fi.Ingredient)
                .ToList();

            return View(foods);
        }

        
        public IActionResult Create()
        {
            var model = new FoodCreateVM
            {
                Ingredients = _context.Ingredients.Select(i => new IngredientCheckboxItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsSelected = false
                }).ToList()
            };

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(FoodCreateVM model)
        {
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                model.Ingredients = _context.Ingredients.Select(i => new IngredientCheckboxItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsSelected = model.SelectedIngredientIds.Contains(i.Id)
                }).ToList();

                ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
                return View(model);
            }

            var food = new Food
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                IsAvailable = true,
                FoodIngredients = model.SelectedIngredientIds.Select(id => new FoodIngredient
                {
                    IngredientId = id
                }).ToList()
            };

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        
        public IActionResult Update(int id)
        {
            var food = _context.Foods
                .Include(f => f.FoodIngredients)
                .FirstOrDefault(f => f.Id == id);

            if (food == null) return NotFound();

            var model = new FoodUpdateVM
            {
                Id = food.Id,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price,
                ImageUrl = food.ImageUrl,
                CategoryId = food.CategoryId,
                SelectedIngredientIds = food.FoodIngredients.Select(fi => fi.IngredientId).ToList(),
                Ingredients = _context.Ingredients.Select(i => new IngredientCheckboxItem
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsSelected = food.FoodIngredients.Any(fi => fi.IngredientId == i.Id)
                }).ToList()
            };

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", food.CategoryId);
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Update(FoodUpdateVM model)
        {
            var food = _context.Foods
                .Include(f => f.FoodIngredients)
                .FirstOrDefault(f => f.Id == model.Id);

            if (food == null) return NotFound();

            food.Name = model.Name;
            food.Description = model.Description;
            food.Price = model.Price;
            food.ImageUrl = model.ImageUrl;
            food.CategoryId = model.CategoryId;

            
            food.FoodIngredients.Clear();
            food.FoodIngredients = model.SelectedIngredientIds.Select(id => new FoodIngredient
            {
                IngredientId = id
            }).ToList();

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return NotFound();

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }


}
