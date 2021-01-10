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
        public Person Supervisor { get; set; }
        public Person Companion1 { get; set; }
        public Person Companion2 { get; set; }
    }
}
