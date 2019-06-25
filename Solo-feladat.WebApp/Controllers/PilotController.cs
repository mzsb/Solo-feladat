using Microsoft.AspNetCore.Mvc;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Solo_feladat.WebApp.Controllers
{
    [Route("api/Pilot")]
    public class PilotController : Controller
    {
        private readonly IPilotManager pilotManager;
        private IMapper mapper;

        public PilotController(IPilotManager pilotManager, IMapper mapper)
        {
            this.pilotManager = pilotManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pilot>>> Get()
        {
            var pilots = await pilotManager.GetPilotsAsync();

            List<Pilot> mapped = mapper.Map<List<Pilot>>(pilots);

            return mapped;
        }
    }
}
