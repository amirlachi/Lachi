using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lachi.Data.Contexts;
using Lachi.Data.Entities.UserStuff;
using Lachi.Models.Channel;
using Lachi.Models.Common;
using Lachi.Services;
using Lachi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lachi.Controllers
{
    public class ChannelController(ChannelService channelService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Manage(Guid id)
        {
            var channel = await channelService.GetById(id);
            if (channel == null) return NotFound();

            var dto = mapper.Map<UserChannelDto>(channel);
            return View(dto);
        }

        public async Task<IActionResult> Index(BaseRequest request)
        {
            var query = channelService.GetAll()
                .Where(c => c.User.IsActive && !c.User.IsRemoved)
                .ApplyFilters(request)
                .ProjectTo<UserChannelDto>(mapper.ConfigurationProvider);

            var channels = query.ToPagedResult(request.Page, request.PageSize);

            return View(channels);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserChannelCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var channel = mapper.Map<UserChannel>(dto);
            var result = await channelService.Create(channel);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message!);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var channel = await channelService.GetById(id);
            if (channel == null) return NotFound();

            var dto = mapper.Map<UserChannelEditDto>(channel);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserChannelEditDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var channel = await channelService.GetById(dto.Id);
            if (channel == null) return NotFound();

            mapper.Map(dto, channel);
            var result = await channelService.Update(channel);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message!);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var channel = await channelService.GetById(id);
            if (channel == null) return NotFound();

            var result = await channelService.Delete(channel);
            if (!result.IsSuccess)
                ModelState.AddModelError(string.Empty, result.Message!);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Videos(int channelId)
        {
            var videos = await channelService.GetVideos(channelId);
            return View(videos);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVideo(int videoId)
        {
            var result = await channelService.DeleteVideo(videoId);
            return Json(result);
        }

        public async Task<IActionResult> Playlists(int channelId)
        {
            var playlists = await channelService.GetPlaylists(channelId);
            return View(playlists);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlaylist(int playlistId)
        {
            var result = await channelService.DeletePlaylist(playlistId);
            return Json(result);
        }
    }
}
