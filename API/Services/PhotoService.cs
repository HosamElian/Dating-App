using API.Interfaces;

namespace API.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly  IWebHostEnvironment _hostEnvironment;
        public PhotoService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public void AddPhotoAsync(IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images");
                    var extension = Path.GetExtension(file.FileName);
                    // if(productVM.Product.ImageUrl != null)
                    // {
                    //     var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                    //     if (System.IO.File.Exists(oldImagePath))
                    //     {
                    //         System.IO.File.Delete(oldImagePath);
                    //     }
                    // }
                     using (var fileStreams = new FileStream(Path.Combine(uploads, fileName+extension), FileMode.CreateNew))
                    {
                        file.CopyTo(fileStreams);
                    }
                }
        }

        public void DeletePhotoAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}