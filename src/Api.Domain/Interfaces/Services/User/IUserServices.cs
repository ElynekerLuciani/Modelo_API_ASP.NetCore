using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserServices
    {
        Task<UserDTO> Get(Guid id);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTOCreateResult> Post(UserDtoCreate user);
        Task<UserDTOUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);

    }
}