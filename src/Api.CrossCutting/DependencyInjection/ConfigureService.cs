using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependencyService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserServices, UserService>();
        }
    }
}