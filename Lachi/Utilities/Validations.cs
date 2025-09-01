using Lachi.Models.Common;

namespace Lachi.Utilities
{
    public static class Validations
    {
        public static ResultDto IsImageFileValid(string path)
        {
            if (!File.Exists(path))
                return new ResultDto(false, "عکس یافت نشد!");

            try
            {
                string ext = Path.GetExtension(path).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
                if (!allowedExtensions.Contains(ext))
                    return new ResultDto(false, "فرمت عکس مجاز نیست");

                using (var stream = File.OpenRead(path))
                {
                    if (stream.Length <= 0)
                        return new ResultDto(false, "عکس خالی است!");
                }

                return new ResultDto(true);
            }
            catch
            {
                return new ResultDto(false, "در باز کردن عکس مشکلی رخ داد!");
            }
        }
    }
}
