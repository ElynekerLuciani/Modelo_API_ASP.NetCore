using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        public ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementations _repositorio = new UserImplementations(context);
                UserEntity _entity = new UserEntity
                {
                    Email = "teste@mail.com",
                    Name = "Teste Novo"
                };

                var _registroCriado = await _repositorio.InsertAsyn(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("teste@mail.com", _registroCriado.Email);
                Assert.Equal("teste", _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

            }
        }
    }
}