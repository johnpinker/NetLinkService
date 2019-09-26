
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using linkservicenet.Models;
using linkservicenet.Services;

namespace linkservicenet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            var Builder = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();
            Configuration = Builder.Build();
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins, builder => {
                    builder.WithOrigins("http://localhost:5000", "http://localhost:8000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.Configure<LinkDatabaseSettings>(
                Configuration.GetSection(nameof(LinkDatabaseSettings)));
            services.AddSingleton<ILinkDatabaseSettings>( sp =>
                sp.GetRequiredService<IOptions<LinkDatabaseSettings>>().Value);
            services.AddSingleton<ILinkService, LinkService>();


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
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
