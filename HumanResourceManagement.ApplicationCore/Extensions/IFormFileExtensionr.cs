using Microsoft.AspNetCore.Http;

namespace HumanResourceManagement.ApplicationCore.Extensions;
public static class ProfileImageHelper
{
    public static string SaveImage(this IFormFile profileImage)
    {
        //save profile image path to db

        var fileName = profileImage.FileName;
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";   //286352bcs-723eua-cew_img.jpge
        var relativePath = $"/images/profiles/{uniqueFileName}";
        var currentAppPath = Directory.GetCurrentDirectory();
        var fullFilePath = Path.Combine(currentAppPath, $"wwwroot/{relativePath}");

        var stream = File.Create(fullFilePath);
        profileImage.CopyTo(stream);

        //return relative path to save to db;
        return relativePath;
    }
}
