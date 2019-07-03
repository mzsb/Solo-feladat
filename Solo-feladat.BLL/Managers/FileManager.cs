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

        protected abstract void ProcessFile(Model.Models.File file);

        public async Task<bool> InsertFilesAsync(List<Model.Models.File> files)
        {
            foreach (var f in files)
            {
                await context.Files.AddAsync(f);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public void SaveDataFromFile()
        {
            var files = context.Files.ToList();

            foreach (var file in files)
            {
                if (!file.Processed)
                {
                    file.Processed = true;

                    context.SaveChanges();

                    ProcessFile(file);

                    if (context.SaveChanges() > 0)
                    {
                        context.Files.Remove(file);
                    }
                    else
                    {
                        file.Processed = false;
                    }

                    context.SaveChanges();
                }
            }
        }

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
