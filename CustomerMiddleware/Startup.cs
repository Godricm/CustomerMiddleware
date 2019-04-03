using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //定义中间件 硬编码
            //app.Use((context, next) =>
            //{
            //    var cultureQuery = context.Request.Query["culture"];
            //    if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    {
            //        var cultrue = new CultureInfo(cultureQuery);
            //        CultureInfo.CurrentCulture = cultrue;
            //        CultureInfo.CurrentUICulture = cultrue;
            //    }
            //    //下一个可重用类或匿名委托
            //    return next();
            //});

            app.UseRequestCulture();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello {CultureInfo.CurrentCulture.DisplayName}");
            });


        }
    }
}
