using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.Model.Models;
using Solo_feladat.WebApp.Jobs;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Pilot, Administrator")]
    public class UploadLogModel : PageModel
    {
        private readonly ILogFileManager logFileManager;
        private IMapper mapper;

        public string Message { get; set; }

        [BindProperty]
        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public UploadLogModel(ILogFileManager logFileManager, IMapper mapper)
        {
            this.logFileManager = logFileManager;
            this.mapper = mapper;
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

            var files = await logFileManager.ConvertIFormFiles(formFiles);

            var logFiles = new List<LogFile>();

            Guid AppUserid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var f in files)
            {
                logFiles.Add(new LogFile
                {
                    AppUserId = AppUserid,
                    Data = f.Data
                });
            }

            if (logFiles.Count > 0)
            {
                var mapped = mapper.Map<List<Model.Models.File>>(logFiles);

                bool result = await logFileManager.InsertFilesAsync(mapped);

                Message = (result ? "Sikeres" : "Sikertelen") + " fájlfeltöltés";
            }
            return Page();
        }
    }
}