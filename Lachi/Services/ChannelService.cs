using AutoMapper;
using Lachi.Data.Contexts;
using Lachi.Data.Entities.UserStuff;
using Lachi.Data.Entities.VideoStuff;
using Lachi.Models.Common;
using Lachi.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Lachi.Services
{
    public class ChannelService(DataBaseContext db)
    {
        public IQueryable<UserChannel> GetAll() => db.UserChannels
            .Include(c => c.User)
            .Include(c => c.Videos)
            .Include(c => c.Playlists)
            .Where(c => !c.User.IsRemoved && c.User.IsActive);

        public async Task<UserChannel?> GetById(Guid id) =>
            await GetAll().FirstOrDefaultAsync(c => c.UserId == id);

        public async Task<bool> IsExistName(string name) =>
            await GetAll().AnyAsync(c => c.Name == name);

        public async Task<bool> IsExistTotally(string name) =>
            await db.UserChannels.AnyAsync(c => c.Name == name);

        public async Task<ResultDto> Create(UserChannel channel)
        {
            if (await IsExistName(channel.Name))
                return new ResultDto(false, "کانالی با این نام قبلاً ثبت شده است!");

            if (!string.IsNullOrEmpty(channel.ProfileImagePath))
            {
                var imgCheck = Validations.IsImageFileValid(channel.ProfileImagePath);
                if (!imgCheck.IsSuccess) return imgCheck;
            }

            if (!string.IsNullOrEmpty(channel.BannerImagePath))
            {
                var imgCheck = Validations.IsImageFileValid(channel.BannerImagePath);
                if (!imgCheck.IsSuccess) return imgCheck;
            }

            try
            {
                db.UserChannels.Add(channel);
                var saveRes = await db.SaveChangesAsync();
                return saveRes > 0 ? new ResultDto(true) : new ResultDto(false, "کانال جدید درج نشد!");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داده، با پشتیبانی تماس بگیرید!");
            }
        }

        public async Task<ResultDto> Update(UserChannel channel)
        {
            try
            {
                db.UserChannels.Update(channel);
                var saveRes = await db.SaveChangesAsync();
                return saveRes > 0 ? new ResultDto(true) : new ResultDto(false, "تغییرات ذخیره نشد!");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داده، با پشتیبانی تماس بگیرید!");
            }
        }

        public async Task<ResultDto> Delete(UserChannel channel)
        {
            try
            {
                channel.User.IsActive = false;
                channel.User.IsRemoved = true;

                db.UserChannels.Update(channel);
                var saveRes = await db.SaveChangesAsync();
                return saveRes > 0 ? new ResultDto(true) : new ResultDto(false, "کانال حذف نشد!");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داده، با پشتیبانی تماس بگیرید!");
            }
        }

        public async Task<List<Video>> GetVideos(int channelId) =>
            await db.Videos.Where(v => v.UserChannelId == channelId).ToListAsync();

        public async Task<ResultDto> DeleteVideo(int videoId)
        {
            var video = await db.Videos.FindAsync(videoId);
            if (video == null) return new ResultDto(false, "ویدیو یافت نشد!");

            try
            {
                db.Videos.Remove(video);
                var saveRes = await db.SaveChangesAsync();
                return saveRes > 0 ? new ResultDto(true) : new ResultDto(false, "ویدیو حذف نشد!");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داده!");
            }
        }

        public async Task<List<Playlist>> GetPlaylists(int channelId) =>
            await db.Playlists.Where(p => p.UserChannelId == channelId).ToListAsync();

        public async Task<ResultDto> DeletePlaylist(int playlistId)
        {
            var playlist = await db.Playlists.FindAsync(playlistId);
            if (playlist == null) return new ResultDto(false, "پلی‌لیست یافت نشد!");

            try
            {
                db.Playlists.Remove(playlist);
                var saveRes = await db.SaveChangesAsync();
                return saveRes > 0 ? new ResultDto(true) : new ResultDto(false, "پلی‌لیست حذف نشد!");
            }
            catch
            {
                return new ResultDto(false, "خطایی در سیستم رخ داده!");
            }
        }
    }
}
