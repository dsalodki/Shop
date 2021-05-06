using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class AuthController : Controller
    {
        private IOperatorRepository _repository;
        public AuthController(IOperatorRepository operatorRepository)
        {
            _repository = operatorRepository;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(AuthViewModel model)
        {
            if(model.UserName == "admin" && model.Password == "123")
            {
                //todo: logged as admin
                var principal = CreateAdmin();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Admin");
            }

            try
            {
                var user = _repository.SignIn(model.UserName, model.Password);
                if (user != null)
                {
                    // todo: logged as operator

                    var principal = CreatePrincipal(user);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NotAllowedPage()
        {
            return View();
        }

        private ClaimsPrincipal CreateAdmin()
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", "0"),
                new Claim(ClaimTypes.Name, "Administrator"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            return principal;
        }

        private ClaimsPrincipal CreatePrincipal(Operator user)
        {
            var claims = new List<Claim>
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Operator")
                };
            var principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            return principal;
        }
    }
}
