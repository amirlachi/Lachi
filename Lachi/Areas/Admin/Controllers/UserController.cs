using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.UserStuff;
using Lachi.Models.Common;
using Lachi.Utilities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

using NuGet.Packaging.Core;

namespace Lachi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(UserManager<User> userManager) : Controller
    {
        public IActionResult Index(BaseRequest request)
        {
            var users = userManager.Users
                .ApplyFilters(request)
                .Select(x=> new UserDto
                {
                    CreateAt = x.CreateAt,
                    CreatedBy = new Models.CreateByDto
                    {
                        UserName = x.UserName!,
                        FullName = x.CreatedBy.FirstName+" "+x.CreatedBy.LastName,
                    },
                    FullName = x.FirstName+ " " + x.LastName,
                    IsActive = x.IsActive,
                    UpdateAt = x.UpdateAt,
                    UpdatedBy = new Models.UpdateByDto
                    {
                        UserName = x.UserName!,
                        FullName = x.UpdatedBy==null ? string.Empty
                            :x.UpdatedBy.FirstName + " " + x.UpdatedBy.LastName,
                    },
                    UserName = x.UserName!,
                    UploadedVideoCounts = x.UploadedVideos != null ? x.UploadedVideos.Count() : 0,
                })
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
    }
}
