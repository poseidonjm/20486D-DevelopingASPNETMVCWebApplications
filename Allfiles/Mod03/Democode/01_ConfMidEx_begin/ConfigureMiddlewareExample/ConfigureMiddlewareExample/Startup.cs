﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigureMiddlewareExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Request path "+ context.Request.Path.Value + "<br/>" );
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from custom Middleware");
            });
        }
    }
}
