using Microsoft.EntityFrameworkCore;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.DAL.Context;
using Solo_feladat.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solo_feladat.BLL.Managers
{
    public class PilotManager : IPilotManager
    {
        private readonly SoloContext context;

        public PilotManager(SoloContext context)
        {
            this.context = context;
        }

        public async Task<List<Pilot>> GetPilotsAsync()
        {
            return await context.Pilots.AsNoTracking()
                                       .ToListAsync();
        }
    }
}
