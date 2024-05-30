using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Infrastructure.Data;
using PruebaTecnica.Infrastructure.Repositories.Interfaces;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PruebaContext Context;
        public UserRepository(PruebaContext context)
        {
            Context = context;
        }
        public async Task AddUser(User user)
        {
            await Context.User.AddAsync(user);
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await Context.User.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await Context.User.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }
    }
}
