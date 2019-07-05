using Hangfire;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Jobs
{
    public class AirportFileProcessJob : IAirportFileProcessJob
    {
        private readonly SoloContext context;
        private readonly IAirportFileManager airportFileManager;

        public AirportFileProcessJob(IAirportFileManager airportFileManager)
        {
            this.airportFileManager = airportFileManager;
        }

        public async void Execute()
        { 
            RecurringJob.AddOrUpdate(() => airportFileManager.ProcessFile(), Cron.Minutely);
        }
    }


}
