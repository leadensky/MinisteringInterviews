using System;

namespace MinisteringInterviews.Domain
{
    public class Appointment : DomainObject
    {
        public Appointment()
        {
            Id = new Guid();
        }

        public Companionship Companionship { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }
    }
}
