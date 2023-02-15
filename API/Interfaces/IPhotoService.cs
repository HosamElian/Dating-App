using API.Entities;

namespace API.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoResult> AddPhotoAsync(IFormFile file);         
        Task<bool> DeletePhotoAsync(string url);         
    }
}