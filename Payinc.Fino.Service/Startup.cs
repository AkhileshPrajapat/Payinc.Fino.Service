using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Payinc.Fino.Service
{
    public class Startup
    {
        public static IDictionary<string, string> AppSetting = new Dictionary<string, string>();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region  ADD JSON OPTIONS GO IN .NET CORE 3.0?
            services.AddMvc().AddJsonOptions(o => { o.JsonSerializerOptions.PropertyNamingPolicy = null; o.JsonSerializerOptions.DictionaryKeyPolicy = null; });
            #endregion

            #region Register the Swagger services
            services.AddMvc();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Fino", Version = "v1", Description = "payinc Info Service API", });
            });

            services.AddMvcCore().AddApiExplorer();
            #endregion

            #region SET ALL APP SETTING URL
            AppSetting.Add(AppSettings.DefaultConnection, Configuration.GetSection(AppSettings.ConnectionStrings).GetSection(AppSettings.DefaultConnection).Value);
            AppSetting.Add(AppSettings.FINO_URL, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.FINO_URL).Value);
            AppSetting.Add(AppSettings.FINO_AUTHKEY_KEY, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.FINO_AUTHKEY_KEY).Value);
            AppSetting.Add(AppSettings.FINO_PARTNERID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.FINO_PARTNERID).Value);
            AppSetting.Add(AppSettings.BODY_ENCRYPTION_KEY, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.BODY_ENCRYPTION_KEY).Value);
            AppSetting.Add(AppSettings.HEADER_ENCRYPTION_KEY, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.HEADER_ENCRYPTION_KEY).Value);
            AppSetting.Add(AppSettings.CLIENT_NAME, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.CLIENT_NAME).Value);
            AppSetting.Add(AppSettings.VERSION, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.VERSION).Value);
            //AppSetting.Add(AppSettings.SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.SERVICEID).Value);
            AppSetting.Add(AppSettings.GetClientMaster_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.GetClientMaster_SERVICEID).Value);
            AppSetting.Add(AppSettings.GetClientFieldMaster_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.GetClientFieldMaster_SERVICEID).Value);
            AppSetting.Add(AppSettings.CashCollectionVerification_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.CashCollectionVerification_SERVICEID).Value);
            AppSetting.Add(AppSettings.CMSTransaction_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.CMSTransaction_SERVICEID).Value);
            AppSetting.Add(AppSettings.GetOTP_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.GetOTP_SERVICEID).Value);
            AppSetting.Add(AppSettings.TxnEnquiry_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.TxnEnquiry_SERVICEID).Value);
            AppSetting.Add(AppSettings.ResendOTP_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.ResendOTP_SERVICEID).Value);
            AppSetting.Add(AppSettings.GetPrintTemplate_SERVICEID, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.GetPrintTemplate_SERVICEID).Value);

            AppSetting.Add(AppSettings.IS_LOG, Configuration.GetSection(AppSettings.Service_Config).GetSection(AppSettings.IS_LOG).Value);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "payinc.core v1"); });
            #endregion

            #region LOGGER FACTORY
            loggerFactory.AddLog4Net(); // << Add this line
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
