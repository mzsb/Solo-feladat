using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Dtos;
using Solo_feladat.BLL.Interfaces;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Pilot, Administrator")]
    public class FlightDetailsModel : PageModel
    {
        private readonly IFlightManager flightManager;
        private IMapper mapper;

        [BindProperty]
        public Flight Flight { get; set; }
        public List<Coordinate> Coordinates { get; set; }

        public FlightDetailsModel(IFlightManager flightManager, IMapper mapper)
        {
            this.flightManager = flightManager;
            this.mapper = mapper;
        }

        public async Task OnGetAsync(Guid Id)
        {
            Flight = mapper.Map<Flight>(await flightManager.GetFlightByIdAsync(Id));

            Coordinates = Flight.Coordinates.ToList();
        }

        public async Task<ActionResult> OnPostAcceptAsync(Guid Id)
        {
            Flight = mapper.Map<Flight>(await flightManager.GetFlightByIdAsync(Id));

            Flight.Status = Model.Models.FlightStatus.Accepted;

            var mapped = mapper.Map<Solo_feladat.Model.Models.Flight>(Flight);

            await flightManager.UpdateFlightAsync(mapped);

            return Page();
        }

        public async Task<ActionResult> OnPostDeniedAsync(Guid Id)
        {
            Flight = mapper.Map<Flight>(await flightManager.GetFlightByIdAsync(Id));

            Flight.Status = Model.Models.FlightStatus.Denied;

            var mapped = mapper.Map<Solo_feladat.Model.Models.Flight>(Flight);

            await flightManager.UpdateFlightAsync(mapped);

            return Page();
        }

    }
}