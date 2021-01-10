using System;
using System.Collections.Generic;
using System.Text;

namespace MinisteringInterviews.Domain
{
    public abstract class DomainObject
    {
        public Guid Id { get; set; }
    }
}
