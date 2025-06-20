using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    using Final_Project.DataAccessLayer;
    using Final_Project.Models;
    using Final_Project.ViewModels.CustomerViewModels;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class CustomerController : Controller
    {
        private readonly DannyDbContext _context;
        private readonly IValidator<CustomerViewModel> _validator;

        public CustomerController(DannyDbContext context, IValidator<CustomerViewModel> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                foreach (var err in validationResult.Errors)
                {
                    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                }
                return View(model);
            }

            var customer = new Customer
            {
                FullName = model.FullName,
                Phone = model.Phone,
                Email = model.Email,
                IsRegistered = false  
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }

}
