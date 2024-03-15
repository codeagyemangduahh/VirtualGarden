using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VirtualGarden;


[Area("Identity")]
public class AccountController : Controller
{
    private readonly UserManager<Gardener> _UserManager;
    private readonly SignInManager<Gardener> _SignInManager;

    public AccountController(UserManager<Gardener> userManager, SignInManager<Gardener> signInManager)
    {
        _UserManager = userManager;
        _SignInManager = signInManager;
    }
    
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var gardener = registerViewModel.ToGardener();
            var result = await _UserManager.CreateAsync(gardener, registerViewModel.Password);

            if (result.Succeeded)
            {
                await _SignInManager.PasswordSignInAsync(gardener, registerViewModel.Password, true, false);
                 return RedirectToAction("Index", "Gardens", new { area = "" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _SignInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Gardens", new { area = "" });
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View();
    }
}
