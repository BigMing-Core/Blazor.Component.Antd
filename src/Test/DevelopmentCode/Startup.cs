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
using LuanNiao.Blazor.Component.Antd; 
using LuanNiao.Blazor.Core;

namespace DevelopmentCode
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
            Translater.AddLanguageFile(new Translater.SourceItem[]
            {
                new Translater.SourceItem() {  CultureName="cn", ItemType= Translater.SourceItemType.OrignalString, Data=DevelopmentCode.Properties.Resources.cn},
                new Translater.SourceItem() {  CultureName="en", ItemType= Translater.SourceItemType.OrignalString, Data=DevelopmentCode.Properties.Resources.en},
            });
            Translater.ConvertTo("en");
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddLuanNiaoBlazorAntdExtensions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
