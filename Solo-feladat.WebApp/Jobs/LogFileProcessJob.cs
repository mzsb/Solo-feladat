using Hangfire;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.DAL.Context;
using Solo_feladat.WebApp.Jobs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Jobs
{
    public class LogFileProcessJob : ILogFileProcessJob
    {
        private readonly SoloContext context;

        public LogFileProcessJob(SoloContext context)
        {
            this.context = context;
        }

        public void Execute()
        {
            IFileManager logFileManager = new LogFileManager(context);

            RecurringJob.AddOrUpdate(() => logFileManager.SaveDataFromFile(), Cron.Minutely);
        }
    }
}
