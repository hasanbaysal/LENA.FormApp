using LENA.FormApp.Business.Interfaces;
using LENA.FormApp.Dtos.UserDtos;
using LENA.FormApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace LENA.FormApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn() => View();
        public IActionResult SignUp() => View();


        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto dto, string returnUrl = "/")
        {

            var result = await userService.CheckUserPassword(dto);

            if (result.ResponseType == Common.Enums.ResponseType.NotFound)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            if (result.ResponseType == Common.Enums.ResponseType.ValidationError)
            {
                ModelState.Clear();
                result.Errors!.ForEach(x => ModelState.AddModelError(x.ProppertyName!, x.ErorrMessage!));

                return View(dto);
            }


            var claims = new List<Claim>();
            claims.Add(new(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
            claims.Add(new(ClaimTypes.Name, result.Data.UserName));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme
              , new ClaimsPrincipal(claimsIdentity)
              , authProperties);

            return Redirect(returnUrl);
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateDto dto)
        {

            var result = await userService.CreateAsync(dto);

            if (result.ResponseType == Common.Enums.ResponseType.ValidationError)
            {

                ModelState.Clear();
                result.Errors!.ForEach(x => ModelState.AddModelError(x.ProppertyName!, x.ErorrMessage!));

                return View(dto);
            }

            if (result.ResponseType == Common.Enums.ResponseType.Error)
            {
                
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }


            return RedirectToAction(nameof(SignIn));
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}