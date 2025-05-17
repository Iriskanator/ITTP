using ITTP;
using ITTP_App;
using ITTP_Data;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ITTP
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddData(Configuration);
            services.AddApp();
            services.AddHttpLogging();

            services.AddControllersWithViews();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "UserService", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                foreach (FileInfo file in new DirectoryInfo(AppContext.BaseDirectory).GetFiles(
                             Assembly.GetExecutingAssembly().GetName().Name! + ".xml"))
                    c.IncludeXmlComments(file.FullName);

                c.EnableAnnotations(enableAnnotationsForInheritance: true,
                    enableAnnotationsForPolymorphism: true
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder global, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            global.MapOnPublicPort(publicApp =>
            {
                publicApp.UseHttpLogging();

                publicApp.UseSwagger();
                publicApp.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService");

                    options.EnableDeepLinking();
                });

                publicApp.UseRouting();

                publicApp.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers().AllowAnonymous();
                });
            });
        }

    }
}
