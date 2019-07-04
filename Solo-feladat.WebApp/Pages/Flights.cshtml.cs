using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Solo_feladat.BLL.Dtos;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.WebApp.Helper;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Administrator")]
    public class FlightsModel : PageModel
    {
        private readonly IFlightManager flightManager;
        private IMapper mapper;

        public List<SelectListItem> Statuses { get; set; }
        = new List<SelectListItem>
        {
            new SelectListItem("Elfogadásra vár", Model.Models.FlightStatus.Wait.ToString()),
            new SelectListItem("Elfogadva", Model.Models.FlightStatus.Accepted.ToString()),
            new SelectListItem("Elutasítva", Model.Models.FlightStatus.Denied.ToString())
        };

        [BindProperty]
        public string Status { get; set; }

        public FlightsModel(IFlightManager flightManager, IMapper mapper)
        {
            this.flightManager = flightManager;
            this.mapper = mapper;
        }

        public IList<Flight> Flights { get; set; }

        public async Task OnGetAsync()
        {
            var flights = await flightManager.GetFlightsByStatusAsync(Model.Models.FlightStatus.Wait);

            Flights = mapper.Map<List<Flight>>(flights);
        }

        public async Task OnPostAsync()
        {
            var flights = await flightManager.GetFlightsByStatusAsync(Status.ToFlightStatus());

            Flights = mapper.Map<List<Flight>>(flights);
        }
    }
}