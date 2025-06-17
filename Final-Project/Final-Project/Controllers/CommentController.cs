using Final_Project.Models;
using Final_Project.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
   
    
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CommentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

         
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            
            var comment = new Comment { Id = id, Text = "Misal", BlogId = 1 };
            var viewModel = new CommentUpdateVM
            {
                Id = comment.Id,
                Text = comment.Text,
                BlogId = comment.BlogId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CommentUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            return RedirectToAction("Index");

        }
    }

}
