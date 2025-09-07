using Lachi.Models.Common;

namespace Lachi.Utilities
{
    public static class Validations
    {
        public static ResultDto IsFileValid(string path, string[] allowedExtensions)
        {
            if (!File.Exists(path))
                return new ResultDto(false, "فایل یافت نشد!");

            try
            {
                string ext = Path.GetExtension(path).ToLower();
                if (!allowedExtensions.Contains(ext))
                    return new ResultDto(false, "فرمت فایل مجاز نیست");

                using (var stream = File.OpenRead(path))
                {
                    if (stream.Length <= 0)
                        return new ResultDto(false, "فایل خالی است!");
                }

                return new ResultDto(true);
            }
            catch
            {
                return new ResultDto(false, "در باز کردن فایل مشکلی رخ داد!");
            }
        }

        public static ResultDto IsImageFileValid(string path)
            => IsFileValid(path, new[] { ".jpg", ".jpeg", ".png" });

        public static ResultDto IsVideoFileValid(string path)
            => IsFileValid(path, new[] { ".mp4", ".avi", ".mov", ".mkv" });

    }
}
