using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoExecutarGetAll : UsuarioTestes
    {

        private IUserServices _service;
        private Mock<IUserServices> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GETAll")]
        public async Task E_Possivel_Executar_GetAll()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UserDTO>();
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;
            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);

        }
    }
}