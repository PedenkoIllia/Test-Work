using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LogicLayer.DataTransferObjects;
using LogicLayer.Interfaces;
using LogicLayer.Mapper;
using LogicLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Root;
using WEB.Validators;

namespace WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            DependencyInjector.InjectDependencies(services, connection);

            var mappingConfig = new MapperConfiguration(mcfg =>
            {
                mcfg.AddProfile(new MapProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers().
                AddFluentValidation();
            services.AddTransient<IValidator<RecordDTO>, RecordValidator>();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
