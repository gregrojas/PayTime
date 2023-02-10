using MediatR;
using Microsoft.Extensions.Options;
using Serilog;
using PayTime.API.StartupExtensions;
using PayTime.Application.Handlers;
using PayTime.Application.Queries;
using PayTime.Application.Commands;

namespace PayTime.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
            });

            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(GetDependentsByIdQuery).Assembly);
            services.AddMediatR(typeof(GetPayrollByIdQuery).Assembly);
            services.AddMediatR(typeof(AddDependentCommand).Assembly);
            services.AddMediatR(typeof(CreatePayrollCommand).Assembly);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.ConfigureSwagger();

            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel
                .Information()
                .WriteTo.Console()
                .Enrich.WithCorrelationIdHeader()
                .Enrich.WithCorrelationId();

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}
