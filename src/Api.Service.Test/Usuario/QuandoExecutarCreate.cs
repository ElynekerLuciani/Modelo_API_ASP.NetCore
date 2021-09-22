using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarCreate : UsuarioTestes
    {
        private IUserServices _service;
        private Mock<IUserServices> _serviceMock;

        [Fact(DisplayName = "É possível executar o método create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

        }

    }
}