using MinisteringInterviews.Domain;

namespace MinisteringInterviews.Data
{
    public static class PersonExtensions
    {
        public static string ChurchName (this Member person)
        {
            return $"Brother {person.LastName}";
        }
    }
}
