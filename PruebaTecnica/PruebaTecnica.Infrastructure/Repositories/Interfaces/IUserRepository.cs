using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAll();
        Task<User> FindById(int id);
        Task AddUser(User user);
    }
}
