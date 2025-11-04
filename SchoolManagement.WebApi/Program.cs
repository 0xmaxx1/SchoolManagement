using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using SchoolManagement.Core;
using SchoolManagement.Core.MiddleWare;
using SchoolManagement.Infrastructure;
using SchoolManagement.Services;
using System.Globalization;

namespace SchoolManagement.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Enable Cross-Origin Requests (CORS)

            var Cors = "_cors";


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: Cors,
                                  policy =>
                                  {

                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();

                                  });
            });

            #endregion


            // Add services to the container.

            #region Add Services To DI Container

            builder.Services.AddControllers()
                                      /*    .AddJsonOptions(opt =>
                                          {
                                              opt.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                                          })*/;

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services
                .AddDependenciesToContainer(builder.Configuration)
                .AddPersistenceServices()
                .AddServiceCoreToContainer();


            #endregion

            #region Localizations

            AddLocalizerInDIContianer(builder);

            #endregion


            var app = builder.Build();


            #region Localization Midleware
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);


            #endregion

            app.UseMiddleware<ErrorHandlerMiddleWare>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(Cors);


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void AddLocalizerInDIContianer(WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
              {
                  new CultureInfo("en-US"),
                  //new CultureInfo("de-DE"),
                  //new CultureInfo("fr-FR"),
                  new CultureInfo("ar-EG")
              };

                options.DefaultRequestCulture = new RequestCulture("ar-EG"); // Default The Language
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            //builder.Services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    options.DefaultRequestCulture = new RequestCulture("ar-EG");
            //});






        }
    }
}
