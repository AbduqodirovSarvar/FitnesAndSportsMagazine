using Microsoft.AspNetCore.Http;

namespace Fitnes.Application.Interfaces
{
    public interface IFileSaveToFolder
    {
        Task<string> SaveToFolderAsync(IFormFile file);
    }
}
