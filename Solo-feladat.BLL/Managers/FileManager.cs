using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public abstract class FileManager : IFileManager
    {
        private readonly SoloContext context;

        public FileManager(SoloContext context)
        {
            this.context = context;
        }

        public async Task<bool> InsertFilesAsync(List<Model.Models.File> files)
        {
            foreach (var f in files)
            {
                context.Files.Add(f);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public abstract Task ProcessFile();

        /// <summary>
        /// A parameterkent kapott IFormFileokbol kinyeri a binaris adatot, amit Fileokba ment.
        /// </summary>
        /// <param name="formFiles">Feldolgozando IFormFileok</param>
        /// <returns>IFormFileokbol letrehozott Fileok</returns>
        public async Task<List<Dtos.File>> ConvertIFormFiles(List<IFormFile> formFiles)
        {
            List<Dtos.File> files = new List<Dtos.File>();

            foreach (var formFile in formFiles)
            {
                if (formFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);

                        files.Add(
                        new Dtos.File
                        {
                            Data = memoryStream.ToArray(),
                        });
                    }
                }
            }

            return files;
        }
    }
}
