using ChatProject.Models;
using ChatProject.Models.Context;
using DepoYonetV2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChatProject.Controllers
{
    public class RegisterController : Controller
    {

        private readonly dbContext _dbContext;

        public RegisterController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            JsonModel success = new JsonModel();
            if (ModelState.IsValid)
            {
                if(!_dbContext.Users.Where(x=> x.Email == user.Email).Any())
                {
                    User userInfo = new User
                    {
                        Name = user.Name,
                        Password = user.Password,
                        Email = user.Email,
                        Role = "User"
                    };
                    _dbContext.Users.Add(userInfo);
                    _dbContext.SaveChanges();
                    return Redirect("/Login/Index");
                }
                else
                {
                    success.Success = false;
                    success.Message = "Bu e-mail adresi ile biri kayıtlı.";
                    return Json(success);
                }
                
            }
            else
            {
                success.Success = false;
                success.Message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).FirstOrDefault();
                return Json(success);
            }
            
        }
    }
}
