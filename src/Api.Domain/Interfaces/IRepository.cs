using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;


/*
Vai receber qualquer tipo de entidades para realização do CRUD
*/

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsyn(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);

    }
}