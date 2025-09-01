using Lachi.Data.Contexts;
using Lachi.Data.Entities.GameStuff;
using Lachi.Models.Common;
using Lachi.Utilities;

using System.Text;
using System.Threading.Tasks;

namespace Lachi.Services
{
    public class CountryService(DataBaseContext db)
    {
        public IQueryable<Country> Get() =>
            db.Countries.Where(x => !x.IsRemoved && x.IsActive);

        public async Task<ResultDto> Create(Country country) 
        {
            if (db.Countries.Any(x => x.Name == country.Name))
                return new ResultDto(false, "کشوری با این نام قبلا ثبت شدع");

            if (!string.IsNullOrEmpty(country.FlagPath))
            {
                var imageValidation = Validations.IsImageFileValid(country.FlagPath);
                if (!imageValidation.IsSuccess)
                    return imageValidation;
            }

            try
            {
                db.Countries.Add(country);
                var saveRes = await db.SaveChangesAsync();

                return saveRes > 0 ? new ResultDto(true)
                    : new ResultDto(false, "کشور جدید درج نشد!";
            }
            catch (Exception)
            {
                return new ResultDto(false, "خطایی در سیستم رخ داده، با پشتیبانی تماس بگیرید!");
            }

        }
    }
}
