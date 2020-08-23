using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Root
{
    public class DependencyInjector
    {
        public DependencyInjector()
        { }

        public static void InjectDependencies(IServiceCollection services, string databaseConnectionString)
        {
            services.AddScoped<IUnitOfWork, RecordUnitOfWork>();
            services.AddScoped<IRecordService, RecordService>();
            services.AddDbContext<RecordContext>(options => options.UseSqlServer(databaseConnectionString));
        }
    }
}
