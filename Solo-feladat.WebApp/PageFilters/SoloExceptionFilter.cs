using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solo_feladat.WebApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.PageFilters
{
    public class SoloExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public SoloExceptionFilter(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if (!hostingEnvironment.IsDevelopment())
            {
                return;
            }

            context.ExceptionHandled = true;

            _ErrorModel m = new _ErrorModel { Foo = "2" };

            context.Result = m.RedirectToPage("/_Error");
        }
    }
}
