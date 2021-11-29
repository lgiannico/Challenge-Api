using Challenge_Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Api
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
      services.AddControllers()
      .ConfigureApiBehaviorOptions(options =>
       {
         options.SuppressConsumesConstraintForFormFileParameters = true;
         options.SuppressInferBindingSourcesForParameters = true;
         options.SuppressModelStateInvalidFilter = true;
         options.SuppressMapClientErrors = true;
         options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
             "https://httpstatuses.com/404";
       });
      services.AddCors(o => o.AddPolicy("corsApp", builder =>
         {
           builder.AllowAnyOrigin();
           builder.AllowAnyMethod();
           builder.AllowAnyHeader();
         }));

      services.AddSingleton<NewsService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors("corsApp");
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
