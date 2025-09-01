using Lachi.Data.Entities.UserStuff;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Lachi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(UserManager<User> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
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
