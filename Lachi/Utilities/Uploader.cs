using Humanizer;

namespace Lachi.Utilities
{
    public static class Uploader
    {
        public static async Task<string?> UploadImageAsync(IFormFile file, string targetPath, string name)
        {
            string? filePath = null;

            if (file != null && file.Length > 0)
            {
                Directory.CreateDirectory(targetPath);

                string fileName = name + Path.GetExtension(file.FileName);
                filePath = Path.Combine(targetPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return filePath;
        }
    }
}
