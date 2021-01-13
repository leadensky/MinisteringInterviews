using Microsoft.EntityFrameworkCore;
using MinisteringInterviews.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisteringInterviews.Data.Repositories
{
    public class MemberRepository : RepositoryBase<Member>
    {
        public MemberRepository(AppDbContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Member>> ListAsync()
        {
            return await _context.Members.ToListAsync();
        }
    }
}
