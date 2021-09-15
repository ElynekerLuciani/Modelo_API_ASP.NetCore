using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

/*
Para fazer o login é preciso uma forma para utilizar o e-mail. Como
não existe um método para esta ação dentro do IRepository, criamos
esta interface para esta ação específica que contenha este atributo. 
Não podemos colocá-lo em IRepository pois nem todos contém o atributo
e-mail.
*/

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}