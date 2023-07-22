using ChatProject.Models;
using ChatProject.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Claims;

namespace ChatProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly dbContext _dbContext;

        public LoginController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            if(user.Email != null && user.Password != null)
            {
                User userInfo = _dbContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (userInfo != null)
                {
                    var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                                new Claim(ClaimTypes.Name, userInfo.Name),
                            };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                            new ClaimsPrincipal(claimsIdentity),
                                                            authProperties);
                    return Redirect("/Home/Index");
                }
                else
                {
                    return RedirectToAction("Index");

                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
