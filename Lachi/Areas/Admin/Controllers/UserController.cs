using AutoMapper;
using AutoMapper.QueryableExtensions;

using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.UserStuff;
using Lachi.Models.Common;
using Lachi.Services;
using Lachi.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.Win32;

using NuGet.Packaging.Core;

namespace Lachi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController(UserManager<User> userManager, IMapper mapper, FollowService followService) : Controller
    {
        public IActionResult Index(BaseRequest request)
        {
            var users = userManager.Users
                .Where(u => !u.IsRemoved)
                .ApplyFilters(request)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .ToPagedResult(request.Page, request.PageSize);

            return View(users);
        }

        //public IActionResult Ar()
        //{

        //    User newUser = new User()
        //    {
        //        FirstName = "امیررضا",
        //        LastName = "لچینانی",
        //        UserName = "ar.lachinani@Lachi.com",
        //        Email = "ar.lachinani@Lachi.com",
        //    };

        //    newUser.CreatedById = newUser.Id;

        //    var result = userManager.CreateAsync(newUser, "arLachi123@").Result;
        //    return Ok(result.Succeeded);
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var newUser = mapper.Map<User>(dto);
            var result = await userManager.CreateAsync(newUser, dto.Password);
            
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var item in result.Errors.ToList())
                ModelState.AddModelError(string.Empty, item.Description);
            
            return View(dto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var dto = mapper.Map<UserEditDto>(user);

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var user = await userManager.FindByNameAsync(dto.UserName);
            if (user == null)
                return NotFound();

            mapper.Map(dto, user);
            var result = await userManager.UpdateAsync(user);

            foreach (var item in result.Errors)
                ModelState.AddModelError(string.Empty, item.Description);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            return View(dto);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            user.IsRemoved = true;
            user.IsActive = false;
            await userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            user.IsActive = !user.IsActive;
            user.UpdateAt = DateTime.Now;

            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Follow(Guid followerId, Guid followingId)
        {
            var res = await followService.Follow(followerId, followingId);
            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> Unfollow(Guid followerId, Guid followingId)
        {
            var res = await followService.Unfollow(followerId, followingId);
            return Json(res);
        }
    }
}
