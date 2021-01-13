using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisteringInterviews.Domain
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> ListAsync();
    }
}
