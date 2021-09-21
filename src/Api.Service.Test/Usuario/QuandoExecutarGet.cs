using System;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarGet : UsuarioTestes
    {
        private IUserServices _service;
        private Mock<IUserServices> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GET")]
        public async Task E_Possivel_Executar_Get()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            //Testar um retorno null
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDTO)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUsuario);
            Assert.Null(_record);


        }

    }
}