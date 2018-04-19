using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanSoftStore.UI.Data;
using FanSoftStore.UI.Infra;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            //ADICIONAMOS A AUTENTICAÇÃO
            //USANDO AUTENTICAÇÃO VIA COOKIE
            //DEFINIMOS AS PAGINAS DE LOGIN E LOGOUT
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Conta/Login";
                x.LogoutPath = "/Conta/Logout";
            });


            //ADICIONA O PIPELINE DO MVC 
            services.AddMvc();

            //ADD INJECTION DEPENDENCY

            //NATIVE DEPENDENCY INJECTION
            //services.AddSingleton()

            //DEPENDENCY INJECTION, ESTANCIA UNICA É GERADO UM NOVO PARA CADA REQUEST
            services.AddScoped<DataContext>();

            
            //CADA VEZ QUE NECESSARIO SOBRE UM NOVA INSTANCIA
            //services.AddTransient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline..
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext ctx)
        {
            //VERIFIED IF YOU ARE IN DEBUG LOCALHOST MODE
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //VERIFIED AND CREATE A DATABASE
                DbInitializer.InitDb(ctx);
            }

            //DICIONA A ROTA PADRÃO DO SISTEMA
            //USANDO PAGINAS E CONTROLLERS
            app.UseMvcWithDefaultRoute();

            //THIS IS FOR GET STATIC FILES ( EXAMPLES .css, .js, ...)
            app.UseStaticFiles();

            //USE STATIC FILES INSTALLED BY NPM
            //SET BY PARAMETER CONTENT ROOT PATH WHERE YOUR APPLICATION ARE IN
            app.UseNodeModules(env.ContentRootPath);

            //IF GET HERE THE FILE IS NOT FOUND, SO
            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Resource not found");
            });


            //TAMBEM PARA ADICIONAR AUTENTICAÇÃO VAMOS ADICIONAR UM ITEM EM NOSSO PIPELINE
            app.UseAuthentication();
        }
    }
}
