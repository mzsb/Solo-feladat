using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Dtos;
using Solo_feladat.BLL.Interfaces;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Administrator")]
    public class AirportsModel : PageModel
    {
        private readonly IAirportManager airportManager;
        private IMapper mapper;

        public AirportsModel(IAirportManager airportManager, IMapper mapper)
        {
            this.airportManager = airportManager;
            this.mapper = mapper;
        }

        public void OnGet()
        {

        }
        public async Task<ActionResult> OnPostUploadFile(List<IFormFile> files)
        {
            var filePath = Path.GetTempFileName();

            List<AirportFile> airportFiles = new List<AirportFile>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0 && formFile.FileName.Split('.').Last().Equals("xlsx"))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        airportFiles.Add(
                        new AirportFile
                        {
                            File = memoryStream.ToArray()
                        });
                    }
                }
            }

            if (airportFiles.Count > 0)
            {
                var mapped = mapper.Map<List<Solo_feladat.Model.Models.AirportFile>>(airportFiles);

                await airportManager.InsertAirportFilesAsync(mapped);
            }
            return Page();
        }
    }
}