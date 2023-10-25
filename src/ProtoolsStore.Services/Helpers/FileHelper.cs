using Microsoft.AspNetCore.Http;

namespace ProtoolsStore.Services.Helpers;

public static class FileHelper
{
    /// <summary>
    /// This function for saving images to the wwwroot file asynchronously
    /// </summary>
    /// <param name="file"><see cref="IFormFile"/></param>
    /// <returns>return saved file name end this file static path</returns>
    public static async Task<(string fileName, string filePath)> SaveAsync(IFormFile file, bool isExist = false)
    {
        // genarate file destination
        string fileName = Guid.NewGuid().ToString("N") + "-" + file.FileName.Replace(" ", "-");
        string filePath = Path.Combine(EnvironmentHelper.AttachmentPath, fileName);

        // copy image to the destination as stream 
        FileStream fileStream = File.OpenWrite(filePath);
        await file.CopyToAsync(fileStream);

        // clear
        await fileStream.FlushAsync();
        fileStream.Close();

        return (fileName, Path.Combine(EnvironmentHelper.AttachmentPath, fileName));
    }

    /// <summary>
    /// This founction for remove file from wwwroot by given static path which is given by function parametr
    /// </summary>
    /// <param name="staticPath">file static path</param>
    /// <returns>if file is exists and deleted successfully return true else false</returns>
    public static bool Remove(string staticPath)
    {
        string fullPath = Path.Combine(EnvironmentHelper.WebRootPath, staticPath);

        if (!File.Exists(fullPath))
            return false;

        File.Delete(fullPath);
        return true;
    }
}
