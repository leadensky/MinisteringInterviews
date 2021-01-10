using Common.DomainDrivenDesign;
using System;
using System.Collections.Generic;

namespace MinisteringInterviews.Domain
{
    public class Email : ValueObject
    {
        public string Value { get; }

        public Email(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email must not be empty");

            //TODO: Regex verification of valid email format

            Value = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        /* https://conductofcode.io/post/entities-and-value-objects-in-csharp-for-ddd/ */
        public static implicit operator string(Email value)
        {
            return value.Value;
        }

        public static implicit operator Email(string value)
        {
            return new Email(value);
        }
    }
}
