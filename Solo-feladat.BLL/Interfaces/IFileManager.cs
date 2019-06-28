using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Interfaces
{
    public interface IFileManager
    {
        Task<bool> InsertFilesAsync(List<Solo_feladat.Model.Models.File> file);
        void SaveDataFromFile();
    }
}
