using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarDelete : UsuarioTestes
    {
        private IUserServices _service;
        private Mock<IUserServices> _serviceMock;

        [Fact(DisplayName = "É possível executar delete")]
        public async Task E_Possivel_Executar_Delete()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdUsuario);
            Assert.True(deletado);
        }
    }
}