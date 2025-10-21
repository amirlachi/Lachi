using Lachi.Data.Entities.UserStuff;
using Lachi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Lachi.Data.Contexts;
using Lachi.Services;

namespace Lachi.Controllers
{
    public class AuthController(SignInManager<User> signInManager, UserManager<User> userManager, ChannelService channelService) : Controller
    {
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await signInManager.SignOutAsync();

            var result = await signInManager
                .PasswordSignInAsync(dto.UserName, dto.Password, dto.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(dto.ReturnUrl) && Url.IsLocalUrl(dto.ReturnUrl))
                    return Redirect(dto.ReturnUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است");
            return View(dto);
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new RegisterDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto dto, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(dto);

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsActive = true,
                IsRemoved = false,
                CreateAt = DateTime.UtcNow,
                //CreatedById = new Guid("b3f6841d-be7a-4724-c605-08dde95f8d64")
            };

            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);

                var channel = new UserChannel
                {
                    UserId = user.Id,
                    Name = $"{user.UserName} Channel",
                    CreateAt = DateTime.Now
                };

                await channelService.Create(channel);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(dto);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return RedirectToAction("Login");

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return RedirectToAction("Login");

            var dto = new ProfileDto
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                UserName = user.UserName!,
                Email = user.Email!
            };

            return View(dto);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return RedirectToAction("Login");

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return RedirectToAction("Login");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UserName = dto.UserName;
            user.Email = dto.Email;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "پروفایل با موفقیت ویرایش شد";
                return RedirectToAction("Profile");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(dto);
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
    }
}
