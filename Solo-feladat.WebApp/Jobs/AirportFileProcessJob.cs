using Hangfire;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Jobs
{
    public class AirportFileProcessJob : IAirportFileProcessJob
    {
        private readonly SoloContext context;

        public AirportFileProcessJob(SoloContext context)
        {
            this.context = context;
        }

        public void Execute()
        {
            IFileManager airportFileManager = new AirportFileManager(context);

            RecurringJob.AddOrUpdate(() =>
            airportFileManager.SaveDataFromFile(), Cron.Minutely);
        }
    }
}
