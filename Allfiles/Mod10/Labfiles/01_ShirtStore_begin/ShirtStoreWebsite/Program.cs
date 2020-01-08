﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ShirtStoreWebsite.Data;

namespace ShirtStoreWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((context, logging) =>
            {
                var env = context.HostingEnvironment;
                var config = context.Configuration.GetSection("Logging");

                logging.ClearProviders();

                if (env.IsDevelopment())
                {
                    logging.AddConfiguration(config);
                    logging.AddConsole();
                }
                else
                {
                    logging.AddFile(config);
                }
            })
                .UseStartup<Startup>();
    }
}
