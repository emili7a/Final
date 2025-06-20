using Final_Project.DataAccessLayer;
using Final_Project.Models;
using Final_Project.ViewModels.ContactViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class ContactController : Controller
    {
      
        
            private readonly DannyDbContext _context;
            private readonly IValidator<ContactCreateVM> _validator;

            public ContactController(DannyDbContext context, IValidator<ContactCreateVM> validator)
            {
                _context = context;
                _validator = validator;
            }

      
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(ContactCreateVM model)
            {
                var validationResult = await _validator.ValidateAsync(model);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(model);
                }

                var contact = new Contact
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };

                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Your message has been sent successfully!";
                return RedirectToAction("Create");
            }
        

    }
}
