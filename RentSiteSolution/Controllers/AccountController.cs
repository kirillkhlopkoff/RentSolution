using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentSiteSolution.DATA.Entity.Identity;
using RentSiteSolution.ViewModels.UsersViewModels;

namespace RentSiteSolution.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Метод для отображения страницы регистрации
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Метод для обработки данных регистрации
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    City = model.City
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login"); // Перенаправление на страницу входа
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        // Метод для отображения страницы входа
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Метод для обработки данных входа
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Перенаправление на главную страницу после успешного входа
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        // Метод для выхода пользователя
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Перенаправление на главную страницу после выхода
        }




        // Метод для отображения страницы личного кабинета
        [HttpGet]
        public IActionResult MyAccount()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            var model = new MyAccountViewModel
            {
                UserName = currentUser.UserName
            };
            return View(model);
        }
    }
}
