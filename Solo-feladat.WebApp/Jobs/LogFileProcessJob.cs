using Hangfire;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.DAL.Context;
using Solo_feladat.WebApp.Jobs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Jobs
{
    public class LogFileProcessJob : ILogFileProcessJob
    {
        private readonly SoloContext context;
        private readonly ILogFileManager logFileManager;
        private readonly SemaphoreSlim semaphore;

        public LogFileProcessJob(ILogFileManager logFileManager)
        {
            this.logFileManager = logFileManager;

            semaphore = new SemaphoreSlim(1);
        }

        public void Execute()
        {
            RecurringJob.AddOrUpdate(() => Do(), Cron.Minutely);
        }

        public async Task Do()
        {
            Task t = Task.Run(async () =>
            {
                await logFileManager.ProcessFile();

                await semaphore.WaitAsync();
            });

            Task.WaitAll(t);
        }
    }
}
