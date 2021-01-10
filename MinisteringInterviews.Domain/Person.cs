﻿using System;

namespace MinisteringInterviews.Domain
{
    public class Person : DomainObject
    {
        public Person()
        {
            Id = new Guid();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Email Mobile { get; set; }
        public Email Email { get; set; }
    }
}
