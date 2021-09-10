using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

/*
vamos criar uma fábrica de contextos para tabelas no
banco de dados em tempo de execução da aplicação.
*/
namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Criar migrações
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=admin;Pwd=Freire2096#";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }



    }
}