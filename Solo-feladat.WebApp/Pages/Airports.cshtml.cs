using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Dtos;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.Model.Models;
using Solo_feladat.WebApp.Jobs;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Administrator")]
    public class AirportsModel : PageModel
    {
        private readonly IAirportFileManager airportFileManager;
        private IMapper mapper;

        public string Message { get; set; }

        [BindProperty]
        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public AirportsModel(IAirportFileManager airportFileManager, IMapper mapper)
        {
            this.airportFileManager = airportFileManager;
            this.mapper = mapper;
        }

        public async Task<ActionResult> OnPostUploadFile(List<IFormFile> formFiles)
        {
            foreach (var ff in formFiles)
            {
                if (!ff.FileName.Split('.').Last().Equals("xlsx"))
                {
                    Message = "Csak Excel-fájl tölthető fel";
                    return Page();
                }
            }

            var files = await airportFileManager.ConvertIFormFiles(formFiles);

            var airportFiles = new List<BLL.Dtos.AirportFile>();

            Guid AppUserid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var f in files)
            {
                airportFiles.Add(new BLL.Dtos.AirportFile
                {
                    AppUserId = AppUserid,
                    Data = f.Data
                });
            }

            if (airportFiles.Count > 0)
            {
                var mapped = mapper.Map<List<Model.Models.File>>(airportFiles);

                bool result = await airportFileManager.InsertFilesAsync(mapped);

                Message = result ? "Sikeres" : "Sikertelen" + " fájlfeltöltés";
            }
            return Page();
        }
    }
}