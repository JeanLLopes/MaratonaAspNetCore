﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanSoftStore.UI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FanSoftStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ADICIONA O PIPELINE DO MVC 
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline..
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //VERIFIED IF YOU ARE IN DEBUG LOCALHOST MODE
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //VERIFIED AND CREATE A DATABASE
                DbInitializer.InitDb(new DataContext());
            }

            //DICIONA A ROTA PADRÃO DO SISTEMA
            //USANDO PAGINAS E CONTROLLERS
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
