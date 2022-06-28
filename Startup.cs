using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using aspmvc_react.Models;
using aspmvc_react.Services;
using aspmvc_react.Helpers;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace aspmvc_react
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DBContextModel>(options =>
         {
           options.UseNpgsql(Configuration.GetConnectionString("postgresConnectionString"));
         });
      services.AddControllersWithViews();
        services.AddSession();
        services.AddHttpClient();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddSingleton(new HttpClient(new HttpClientHandler
      {
        AllowAutoRedirect = false,
        UseCookies = false
      }));

      services.AddTransient<UserService>();
      services.AddTransient<AuthenticationHelpers>();
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
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseSession();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=SPARoot}/{action=Index}");
      });
    }
  }
}
