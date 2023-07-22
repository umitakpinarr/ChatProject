using ChatProject.Models;
using ChatProject.Models.Context;
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
            User userInfo = new User {
                Name = user.Name,
                Password = user.Password,
                Email = user.Email
            };
            _dbContext.Users.Add(userInfo);
            _dbContext.SaveChanges();
            return View();
        }
    }
}
