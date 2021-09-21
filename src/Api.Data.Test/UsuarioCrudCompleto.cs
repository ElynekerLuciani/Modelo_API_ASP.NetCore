using System;
using System.Linq;
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
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                //Teste de Isert
                var _registroCriado = await _repositorio.InsertAsyn(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //Teste de Update
                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);

                //Teste de Exist
                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                //Teste Get
                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

                //Teste GetAll
                var _todosResgistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosResgistros);
                Assert.True(_todosResgistros.Count() > 0);

                //Teste Remover
                var _remover = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_remover);

                //Teste FindByLogin da classe UserImplementations
                var _usuarioPadrao = await _repositorio.FindByLogin("admin@mail.com");
                Assert.NotNull(_todosResgistros);
                Assert.Equal("admin@mail.com", _usuarioPadrao.Email);
                Assert.Equal("Admin", _usuarioPadrao.Name);

            }
        }
    }
}