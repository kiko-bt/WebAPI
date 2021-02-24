using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteApp.DataAccess;
using NoteApp.DataAccess.EntityFramework;
using NoteApp.DataModels;

namespace NoteApp.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegiseterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteDbContext>(x => 
                                                 x.UseSqlServer(connectionString));


            //Entity Framework repositories registration
            services.AddTransient<IRepository<UserDTO>, UserRepository>();
            services.AddTransient<IRepository<NoteDTO>, NoteRepository>();



            //ADO.NET Repositories registration
            //services.AddTransient<IRepository<UserDTO>>(x => new UserRepositoryADO(connectionString));
            //services.AddTransient<IRepository<NoteDTO>>(x => new NoteRepositoryADO(connectionString));


            //DAPPER REPOSITORIES REGISTRATION
            //services.AddTransient<IRepository<UserDTO>>(x => new UserRepositoryDapper(connectionString));
            //services.AddTransient<IRepository<NoteDTO>>(x => new NoteRepositoryDapper(connectionString));

            return services;
        }
    }
}
