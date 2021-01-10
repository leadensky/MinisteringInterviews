using MinisteringInterviews.Domain;

namespace MinisteringInterviews.Data
{
    public static class PersonExtensions
    {
        public static string ChurchName (this Person person)
        {
            return $"Brother {person.LastName}";
        }
    }
}
