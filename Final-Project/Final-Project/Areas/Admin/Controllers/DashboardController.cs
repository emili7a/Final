﻿using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
