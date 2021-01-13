using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinisteringInterviews.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinisteringInterviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;

        public MembersController(IMemberService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            var members = await _service.ListAsync();
            return members;
        }
    }
}
