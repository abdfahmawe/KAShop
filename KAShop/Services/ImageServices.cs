public class ImageServices
{
    private string filePath;

    public ImageServices()
    {
        filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Image\");
    }

    public string UploadImage(IFormFile image)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        var fullPath = Path.Combine(filePath, fileName); // ✅ استخدم متغير جديد
        using (var stream = System.IO.File.Create(fullPath))
        {
            image.CopyTo(stream);
        }
        return fileName;
    }

    public bool dellete(string fileName)
    {
        var fullPath = Path.Combine(filePath, fileName); // ✅ متغير جديد وما نعدل على filePath الأصلي
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return true;
        }
        return false;
    }
}
