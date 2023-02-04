using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Interfaces
{
    public interface IPhotoService
    {
        void AddPhotoAsync(IFormFile file);         
        void DeletePhotoAsync(IFormFile file);         
    }
}