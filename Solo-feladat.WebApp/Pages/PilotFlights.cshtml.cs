using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Solo_feladat.WebApp.Pages
{
    public class PilotFlightsModel : PageModel
    {
        //private readonly IPilotManager pilotManager;
        //private IMapper mapper;

        //public FlightsModel(IPilotManager pilotManager, IMapper mapper)
        //{
        //    this.pilotManager = pilotManager;
        //    this.mapper = mapper;
        //}

        //public Pilot Pilot { get; set; }

        //public IList<Flight> Flights { get; set; }

        //public async Task OnGetAsync()
        //{
        //    Pilot = mapper.Map<Pilot>((await pilotManager.GetPilotsAsync()).SingleOrDefault());

        //    var flights = await pilotManager.GetFlightsByPilotIdAsync(Pilot.Id);

        //    Flights = mapper.Map<List<Flight>>(flights);
        //}
    }
}