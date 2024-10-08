using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using Project_Demo.Models.ViewModels;

namespace Project_Demo.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;

        private SignInManager<AppUserModel> _signInManager;
        public AccountController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

		public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl=returnUrl});
        }
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel LoginVM)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(LoginVM.UserName, LoginVM.Password,false,false);
                if (result.Succeeded)
                {
                    return Redirect(LoginVM.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu ");
            }
            return View();
        }
		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
		public async Task<IActionResult> Create(UserModel user)
		{
            if (ModelState.IsValid)
            {
                AppUserModel newUser = new AppUserModel { UserName = user.UserName, Email = user.Email};
                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                if(result.Succeeded)
                {
                    TempData["succes"] = "Tạo thành công user";
                    return Redirect("/account/login");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
			return View(user);
		}
        public async Task<IActionResult> Logout(string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
	}
}
