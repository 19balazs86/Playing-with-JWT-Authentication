using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Playing_with_JWT
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddMvcCore()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
        .AddApiExplorer()
        .AddAuthorization()
        //.AddDataAnnotations()
        .AddJsonFormatters();
        //.AddCors();

      services.AddJwtAuthentication();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
