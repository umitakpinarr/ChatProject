﻿using Microsoft.AspNetCore.Mvc;

namespace ChatProject.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
