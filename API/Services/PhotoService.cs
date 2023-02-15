using System.ComponentModel.DataAnnotations;
using System.Net;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class PhotoService: IPhotoService 
    {
        private readonly  IWebHostEnvironment _hostEnvironment;
        PhotoResult photoResult = new ();

        public PhotoService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            if(_hostEnvironment != null){
                
            }
            
        }
        public async Task<PhotoResult> AddPhotoAsync(IFormFile file)
        {     
                
                
                if(file.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string imgFolderUrl = Directory.GetParent(Environment.CurrentDirectory).FullName + @"\client\src\assets\images";
                    var extension = Path.GetExtension(file.FileName);
               
                     using (var fileStreams = new FileStream(Path.Combine(imgFolderUrl, fileName+extension), FileMode.CreateNew))
                    {
                        file.CopyTo(fileStreams); 
                    }
                    photoResult.IsUploaded = true; 
                    photoResult.Url = "assets/images/" + fileName+extension ;
                    photoResult.PublicId = fileName+extension;
                    return await Task.FromResult(photoResult); 
                }
                photoResult.IsUploaded = false; 
                photoResult.Url = null;
                photoResult.PublicId = null;
                return await Task.FromResult(photoResult); 
        }

        public async Task<bool> DeletePhotoAsync(string Url)
        {       string imgFolderUrl = Directory.GetParent(Environment.CurrentDirectory).FullName + @"\client\src\";
                var oldImagePath = imgFolderUrl + Url;
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                    return await Task.FromResult(true);
                }
            return await Task.FromResult(false);
        }

    }

    
}