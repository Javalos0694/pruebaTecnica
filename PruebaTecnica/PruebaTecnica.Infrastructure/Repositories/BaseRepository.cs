using PruebaTecnica.Infrastructure.Data;
using PruebaTecnica.Infrastructure.Repositories.Interfaces;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly PruebaContext Context;
        public BaseRepository(PruebaContext context)
        {
            Context = context;
        }
        public async Task SaveChangesAsyn()
        {
            await Context.SaveChangesAsync();
        }
    }
}
