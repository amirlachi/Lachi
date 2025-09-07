using Lachi.Data.Contexts;
using Lachi.Data.Entities.UserStuff;
using Lachi.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lachi.Services
{
    public class FollowService(DataBaseContext db)
    {
        public IQueryable<UserFollow> Get(Guid userId) =>
            db.UserFollows.Include(f => f.Following)
                          .Where(f => f.FollowerId == userId);

        public async Task<List<UserFollow>> GetListAsync(Guid userId) =>
            await Get(userId).ToListAsync();

        public async Task<ResultDto> Follow(Guid followerId, Guid followingId)
        {
            if (db.UserFollows.Any(f => f.FollowerId == followerId && f.FollowingId == followingId))
                return new ResultDto(false, "قبلا این کاربر را دنبال کرده‌اید");

            try
            {
                db.UserFollows.Add(new UserFollow
                {
                    FollowerId = followerId,
                    FollowingId = followingId
                });

                var res = await db.SaveChangesAsync();
                return res > 0 ? new ResultDto(true) : new ResultDto(false, "عملیات دنبال کردن انجام نشد");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داد");
            }
        }

        public async Task<ResultDto> Unfollow(Guid followerId, Guid followingId)
        {
            var follow = await db.UserFollows
                                 .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

            if (follow == null)
                return new ResultDto(false, "کاربر مورد نظر در لیست دنبال‌شده‌ها نیست");

            try
            {
                db.UserFollows.Remove(follow);
                var res = await db.SaveChangesAsync();
                return res > 0 ? new ResultDto(true) : new ResultDto(false, "عملیات لغو دنبال کردن انجام نشد");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داد");
            }
        }
    }
}
