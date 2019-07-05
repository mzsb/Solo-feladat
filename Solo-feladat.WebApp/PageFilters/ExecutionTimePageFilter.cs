using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.PageFilters
{
    public class ExecutionTimePageFilter : IPageFilter
    {
        private DateTime requestTime;
        private DateTime responseTime;

        private bool firstRun = true;

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            responseTime = DateTime.Now;

            string modelName = context.HandlerMethod?.MethodInfo?.DeclaringType?.Name ?? "Unknown";
            string methodName = context.HandlerMethod?.MethodInfo?.Name ?? "Unknown";

            using (StreamWriter logger = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "MethodExecutionTime.txt"), true))
            {
                if (firstRun)
                {
                    firstRun = false;

                    logger.WriteLine($"\n\n ###### {DateTime.Now} ###### \n");
                }

                logger.WriteLine($"{modelName}.{methodName}: {(responseTime - requestTime).TotalSeconds} Sec");
            }
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            requestTime = DateTime.Now;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }
    }
}
