using ChatProject.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ChatProject.Models;
using DepoYonetV2.ViewModels;

namespace ChatProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly dbContext _dbContext;

        public AdminController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddGroup(ChatProject.Models.Group group)
        {
            JsonModel success = new JsonModel();
            ChatProject.Models.Group groupInfo = new ChatProject.Models.Group
            {
                GroupName = group.GroupName
            };
            _dbContext.Groups.Add(groupInfo);
            _dbContext.SaveChanges();
            success.Success = true;
            success.Message = "Başarılı bir şekilde eklendi";
            return Json(success);
        }
    }
}
