using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IFileManager
    {
        Task<bool> InsertFilesAsync(List<Model.Models.File> file);
        Task<List<Dtos.File>> ConvertIFormFiles(List<IFormFile> formFiles);
        Task SaveDataFromFile();
    }
}
