using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;

namespace Solo_feladat.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPilotManager pilotmanager;

        public IndexModel(IPilotManager pilotmanager)
        {
            this.pilotmanager = pilotmanager;
        }

        public IList<Pilot> Pilot { get;set; }

        public async Task OnGetAsync()
        {
            Pilot = await pilotmanager.GetPilotsAsync();
        }
    }
}
