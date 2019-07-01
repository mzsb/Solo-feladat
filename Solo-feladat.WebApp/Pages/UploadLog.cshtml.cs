using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.Model.Models;
using Solo_feladat.WebApp.Jobs;
using Solo_feladat.WebApp.Jobs.Interfaces;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Pilot, Administrator")]
    public class UploadLogModel : PageModel
    {
        private readonly ILogFileManager logFileManager;
        private IMapper mapper;
        private ILogFileProcessJob logFileProcessJob;

        public string Message { get; set; }

        [BindProperty]
        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public UploadLogModel(ILogFileManager logFileManager, IMapper mapper, ILogFileProcessJob logFileProcessJob)
        {
            this.logFileManager = logFileManager;
            this.mapper = mapper;
            this.logFileProcessJob = logFileProcessJob;
        }

        public async Task<ActionResult> OnPostUploadFile(List<IFormFile> formFiles)
        {
            foreach (var ff in formFiles)
            {
                if (!ff.FileName.Split('.').Last().Equals("igc"))
                {
                    Message = "Csak IGC-fájl tölthető fel";
                    return Page();
                }
            }

            var logFiles = await logFileManager.ConvertIFormFiles(formFiles);

            Guid AppUserid = Guid.Parse(User.Identity.GetUserId());
            FileType fileType = FileType.Log;

            foreach (var af in logFiles)
            {
                af.AppUserId = AppUserid;
                af.Type = fileType;
            }

            if (logFiles.Count > 0)
            {
                var mapped = mapper.Map<List<Model.Models.File>>(logFiles);

                bool result = await logFileManager.InsertFilesAsync(mapped);

                if (result)
                {
                    logFileProcessJob.Execute();
                    Message = "Sikeres fájlfeltöltés";
                }
                else
                {
                    Message = "Sikertelen fájlfeltöltés";
                }
            }
            return Page();
        }
    }
}