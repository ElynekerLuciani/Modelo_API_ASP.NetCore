using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Data.Implementations;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencyRepository(IServiceCollection serviceCollection)
        {
            //quando acessar, vai conectar com o banco
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementations>();

            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=admin;Pwd=Freire2096#")
           );
        }
    }
}