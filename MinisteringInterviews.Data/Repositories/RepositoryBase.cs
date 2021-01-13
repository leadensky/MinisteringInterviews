using MinisteringInterviews.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinisteringInterviews.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public abstract Task<IEnumerable<T>> ListAsync();
    }
}
