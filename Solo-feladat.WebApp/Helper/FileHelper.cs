using Microsoft.AspNetCore.Http;
using Solo_feladat.BLL.Dtos;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Helper
{
    public static class FileHelper
    {
        public static async Task ConvertIFormFiles(this List<Solo_feladat.BLL.Dtos.File> files, List<IFormFile> formFiles, Guid userId, FileType fileType)
        {
            files.Clear();

            foreach (var formFile in formFiles)
            {
                if (formFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);

                        files.Add(
                        new Solo_feladat.BLL.Dtos.File
                        {
                            AppUserId = userId,
                            Data = memoryStream.ToArray(),
                            Type = fileType
                        });
                    }
                }
            }
        }
    }
}
