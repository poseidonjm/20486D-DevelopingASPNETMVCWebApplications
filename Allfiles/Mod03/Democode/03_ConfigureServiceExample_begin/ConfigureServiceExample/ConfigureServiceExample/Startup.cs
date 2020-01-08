﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ConfigureServiceExample.Services;

namespace ConfigureServiceExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger, Logger>();
        }

        public void Configure(IApplicationBuilder app, ILogger logger)
        {

            app.Run(async (context) =>
            {
                logger.Log("Logged line");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
