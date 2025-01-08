using BLL.Controllers.Bases;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class UsersController : MvcController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userServie)
        {
            _userService = userServie;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserModel user)
        {
            if (ModelState.IsValid) {
                var userModel=_userService.Query().SingleOrDefault(u => u.Record.UserName == user.Record.UserName && u.Record.Password == user.Record.Password && u.Record.IsActive);
                if (userModel == null) {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name , userModel.UserName),
                        new Claim(ClaimTypes.Role , userModel.Role),
                        new Claim("Id", userModel.Record.Id.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var prinicpal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(prinicpal, new AuthenticationProperties(){
                        IsPersistent = true
                    });
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
