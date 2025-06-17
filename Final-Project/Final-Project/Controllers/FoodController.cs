using Final_Project.DataAccessLayer;
using Final_Project.Models;
using Final_Project.ViewModels.FoodViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class FoodController : Controller
    {
      
          private readonly DannyDbContext _context;

            public FoodController(  DannyDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Index()
            {
                var foods = _context.Foods
                    .Select(f => new FoodUpdateVM
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        ImageUrl = f.ImageUrl,
                        IsAvailable = f.IsAvailable,
                        Porsion=f.Porsion,
                        CategoryId = f.CategoryId,
                        Price = f.Price
                    })
                    .ToList();

                return View(foods);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(FoodCreateVM model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var food = new Food
                {
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    IsAvailable = model.IsAvailable,
                    Porsion = model.Porsion,
                    CategoryId = model.CategoryId,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Foods.Add(food);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            [HttpGet]
            public IActionResult Update(int id)
            {
                var food = _context.Foods.Find(id);
                if (food == null)
                {
                    return NotFound();
                }

                var viewModel = new FoodUpdateVM
                {
                    Id = food.Id,
                    Name = food.Name,
                    Description = food.Description,
                    ImageUrl = food.ImageUrl,
                    IsAvailable = food.IsAvailable,
                    Porsion = food.Porsion,
                    CategoryId = food.CategoryId,
                    Price = food.Price
                };
                return View(viewModel);
            }

            [HttpPost]
            public IActionResult Update(FoodUpdateVM model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var food = _context.Foods.Find(model.Id);
                if (food == null)
                {
                    return NotFound();
                }

                food.Name = model.Name;
                food.Description = model.Description;
                food.ImageUrl = model.ImageUrl;
                food.IsAvailable = model.IsAvailable;
                food.Porsion = model.Porsion;
                food.CategoryId = model.CategoryId;
                food.Price = model.Price;

                food.UpdatedAt = DateTime.UtcNow;

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                var food = _context.Foods.Find(id);
                if (food == null)
                {
                    return NotFound();
                }

                _context.Foods.Remove(food);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
        }

    }
