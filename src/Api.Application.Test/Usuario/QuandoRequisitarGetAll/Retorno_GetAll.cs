using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOs.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGetAll
{
    public class Retorno_GetAll
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar get all")]
        public async Task E_Possivel_Invocar_A_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserServices>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDTO>
                {
                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    },

                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDTO>;
            Assert.True(resultValue.Count() == 2);
        }

    }
}