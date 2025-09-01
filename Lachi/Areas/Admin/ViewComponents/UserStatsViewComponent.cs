using Lachi.Areas.Admin.Models.ViewComponents;
using Lachi.Data.Entities.UserStuff;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lachi.Areas.Admin.ViewComponents
{
    public class UserStatsViewComponent(UserManager<User> userManager):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var today = DateTime.Now.Date;
            var yesterday = today.AddDays(-1);

            var totalToday = await userManager.Users
                .CountAsync(u => u.CreateAt >= today && u.CreateAt < today.AddDays(1));

            var totalYesterday = await userManager.Users
                .CountAsync(u => u.CreateAt >= yesterday && u.CreateAt < today);

            double growthPercent = totalYesterday == 0
                ? 100
                : ((double)(totalToday - totalYesterday) / totalYesterday) * 100;

            var model = new UserStatsDto
            {
                TodayUsers = totalToday,
                GrowthPercent = growthPercent
            };
            return View(model);
        }
    }
}
