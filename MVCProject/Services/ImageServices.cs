using Microsoft.Identity.Client;

namespace MVCProject.Services
{
    public class ImageServices
    {
        private string _imageUrl;
        public ImageServices() { 
            _imageUrl= Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");

        }
        public string UploadFile(IFormFile Image)
        {
            var fileName= Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            var filePath = Path.Combine(_imageUrl, fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                Image.CopyTo(stream);
            }
            return fileName;

        }
        public bool DeleteImage(string fileName)
        {
            
            var filePath = Path.Combine(_imageUrl, fileName);
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;

            }
            return false;

        }

    }
}
