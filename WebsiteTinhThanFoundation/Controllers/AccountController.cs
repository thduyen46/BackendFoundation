using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebsiteTinhThanFoundation.Data;
using WebsiteTinhThanFoundation.ViewModels;

namespace WebsiteTinhThanFoundation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(ILogger<AccountController> logger, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            TempData["ReturnUrl"] = returnUrl;
            UserInfoVM model = new();
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserInfoVM model)
        {
            try
            {
                var returnUrl = TempData["ReturnUrl"]?.ToString() ?? Url.Content("~/");
                model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, $"Please fill in the information.");
                    return View();
                }
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không chính xác.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred during sign-in.");
                _logger.LogError(ex.Message.ToString());
            }
            return View(model);
        }
    }
}
