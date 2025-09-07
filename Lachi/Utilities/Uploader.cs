using Humanizer;

namespace Lachi.Utilities
{
    public static class Uploader
    {
        public static async Task<string?> UploadFileAsync(IFormFile file, string targetPath, string name, string[] allowedExtensions)
        {
            if (file == null || file.Length == 0)
                return null;

            Directory.CreateDirectory(targetPath);

            string extension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(extension))
                return null;

            string fileName = name + extension;
            string filePath = Path.Combine(targetPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }

        public static Task<string?> UploadImageAsync(IFormFile file, string targetPath, string name)
            => UploadFileAsync(file, targetPath, name, new[] { ".jpg", ".jpeg", ".png" });

        public static Task<string?> UploadVideoAsync(IFormFile file, string targetPath, string name)
            => UploadFileAsync(file, targetPath, name, new[] { ".mp4", ".avi", ".mov", ".mkv" });

    }
}
