using AutoMapper;

using Lachi.Areas.Admin.Models.Country;
using Lachi.Data.Entities.GameStuff;
using Lachi.Models.Common;
using Lachi.Services;
using Lachi.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Lachi.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CountryController(CountryService service, IWebHostEnvironment env, IMapper mapper) : Controller
    {
        public IActionResult Index(BaseRequest request)
        {
            var data = service.Get()
                .ApplyFilters(request)
                .ToPagedResult(request.Page, request.PageSize);

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateDto dto) 
        {
            if (!ModelState.IsValid)
                return View(dto);

            string? flagPath = null;
            if (dto.Flag is not null)
            {
                var path = Path.Combine(env.WebRootPath, "Images", "Countries");
                flagPath = await Uploader.UploadImageAsync(dto.Flag, path, dto.Name);
            }

            var newCountry = mapper.Map<Country>(dto);
            newCountry.FlagPath = flagPath;

            var createRes = await service.Create(newCountry);
            if (!createRes.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, createRes.Message!);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }   
    }
}
