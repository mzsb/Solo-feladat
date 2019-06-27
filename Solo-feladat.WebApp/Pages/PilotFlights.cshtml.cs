using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Dtos;
using Solo_feladat.BLL.Interfaces;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Pilot, Administrator")]
    public class PilotFlightsModel : PageModel
    {
        private readonly IFlightManager flightManager;
        private IMapper mapper;

        public PilotFlightsModel(IFlightManager flightManager, IMapper mapper)
        {
            this.flightManager = flightManager;
            this.mapper = mapper;
        }

        public IList<Flight> Flights { get; set; }

        public async Task OnGetAsync()
        {
            var flights = await flightManager.GetFlightsByUserIdAsync(Guid.Parse(User.Identity.GetUserId()));

            Flights = mapper.Map<List<Flight>>(flights);
        }
    }
}