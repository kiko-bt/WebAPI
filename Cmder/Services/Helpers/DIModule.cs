using DataModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CommanderDBContext>(x =>
                                            x.UseSqlServer(connectionString));


            return services;
        }
    }
}
