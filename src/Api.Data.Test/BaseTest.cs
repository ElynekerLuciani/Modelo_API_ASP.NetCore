using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Test

{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }


    public class DbTeste : IDisposable
    {
        //para cada teste vai ser criado um banco de dados
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseMySql($"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=admin;Password=Freire2096#"),
                    ServiceLifetime.Transient
            );

            //Utiliza o banco criado e no contexto ele cria e faz as migrações
            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            //Garante que após os testes, o banco criado seja deletado
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}