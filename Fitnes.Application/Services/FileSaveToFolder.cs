using Fitnes.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Services
{
    public class FileSaveToFolder : IFileSaveToFolder
    {
        public async Task<string> SaveToFolderAsync(IFormFile file)
        {
            string folderPath = Directory.GetCurrentDirectory();
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(folderPath, "..", "Fitnes.Application", "Files", "Images", fileName);
            string fp = Path.GetFullPath(filePath);

            using (var stream = new FileStream(fp, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            return fileName;
        }
    }
}
