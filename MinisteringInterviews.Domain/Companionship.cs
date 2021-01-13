using System.Collections.Generic;
using System.Text;

namespace MinisteringInterviews.Domain
{
    public class Companionship : DomainObject
    {
        public Companionship()
        {
            Id = new System.Guid();
        }
        public Member Supervisor { get; set; }
        public Member Companion1 { get; set; }
        public Member Companion2 { get; set; }
    }
}
