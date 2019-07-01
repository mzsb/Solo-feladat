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

        public abstract void ProcessFile(Model.Models.File file);

        public async Task<bool> InsertFilesAsync(List<Solo_feladat.Model.Models.File> files)
        {
            foreach (var f in files)
            {
                await context.Files.AddAsync(f);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public void SaveDataFromFile()
        {
            List<Solo_feladat.Model.Models.File> files = context.Files.ToList();

            if (files.Count > 0)
            {
                var airportFileManager = new AirportFileManager(context);
                var logFileManager = new LogFileManager(context);

                foreach (var f in files)
                {
                    ProcessFile(f);
                }

                if (context.SaveChanges() > 0)
                {
                    foreach (var f in context.Files)
                    {
                        context.Files.Remove(f);
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
