using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinisteringInterviews.Domain;

namespace MinisteringInterviews.Domain.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _repository;

        public MemberService(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Member>> ListAsync()
        {
            return await _repository.ListAsync();
        }
    }
}
