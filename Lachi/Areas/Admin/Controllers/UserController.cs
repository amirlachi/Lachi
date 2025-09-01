using AutoMapper;
using AutoMapper.QueryableExtensions;

using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.UserStuff;
using Lachi.Models.Common;
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
    public class UserController(UserManager<User> userManager, IMapper mapper) : Controller
    {
        public IActionResult Index(BaseRequest request)
        {
            var users = userManager.Users
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

        //    //newUser.CreatedById = newUser.Id;

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
                //ModelState.AddModelError(string.Empty, "ابتدا خطا های ذکر شده را رفع کنید و دوباره اقدام  کنید");
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
    }
}
