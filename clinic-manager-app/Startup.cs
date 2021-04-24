using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ElectronNET.API;
using clinic_manager_app.Data;
using DataLibrary;
using Blazored.Toast;
using Blazored.Modal;
using BlazorTable;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ElectronNET.API.Entities;

namespace clinic_manager_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IDataAccess, SqliteDataAccess>();
            services.AddSingleton<IPatientDAL, PatientDAL>();
            services.AddSingleton<IConsultationDAL, ConsultationDAL>();

            services.AddBlazoredToast();
            services.AddBlazoredModal();
            services.AddBlazorTable();

            services.AddBlazorise(options =>
             {
                 options.ChangeTextOnKeyPress = true; // optional
             })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataAccess dataAccess)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.ApplicationServices
            .UseBootstrapProviders()
            .UseFontAwesomeIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            dataAccess.Setup();

            if (HybridSupport.IsElectronActive)
            {
                ElectronBootstrap();
            }
        }

        public async void ElectronBootstrap()
        {
            var browserWindow = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            {
                Title = "Clinic Manager App",
                Show = false
            });

            Electron.Menu.SetApplicationMenu(new MenuItem[] { });
            await browserWindow.WebContents.Session.ClearCacheAsync();

            browserWindow.OnReadyToShow += () => {
                browserWindow.Show();
                browserWindow.Maximize();
            };
        }
    }
}
