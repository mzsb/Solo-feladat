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
using Solo_feladat.BLL.Dtos;
using Solo_feladat.BLL.Interfaces;
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

            var airportFiles = await airportFileManager.ConvertIFormFiles(formFiles);

            Guid AppUserid = Guid.Parse(User.Identity.GetUserId());
            FileType fileType = FileType.Airport;

            foreach (var af in airportFiles)
            {
                af.AppUserId = AppUserid;
                af.Type = fileType;
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