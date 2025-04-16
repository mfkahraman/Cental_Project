using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class ImageService(IWebHostEnvironment _env) : IImageService
{
    public async Task<string> SaveImageAsync(IFormFile file, string subFolder)
    {
        if (file == null || file.Length == 0)
            return null;

        var extension = Path.GetExtension(file.FileName);
        var newFileName = Guid.NewGuid() + extension;

        // Make sure all images are saved inside /images/
        var relativePath = Path.Combine("/images", subFolder, newFileName);           // For storing in DB
        var absolutePath = Path.Combine(_env.WebRootPath, "images", subFolder, newFileName); // For saving to disk

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);

        using (var stream = new FileStream(absolutePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return relativePath.Replace("\\", "/");
    }


    public async Task<bool> DeleteImageAsync(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
            return false;

        // Normalize path
        var relativePath = imageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
        var fullPath = Path.Combine(_env.WebRootPath, relativePath);

        if (File.Exists(fullPath))
        {
            await Task.Run(() => File.Delete(fullPath));
            return true;
        }

        return false;
    }

}
