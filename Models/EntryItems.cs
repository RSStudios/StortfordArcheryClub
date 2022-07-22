using StortfordArchers.Enumerations;

namespace StortfordArchers.Models
{
    public class EntryItems
    {
        public string EntrantName { get; set; }

        public string SeniorJunior { get; set; }

        public BowType Bowtype { get; set; }

        public string DistanceSaturday { get; set; }
        public string DistanceSunday { get; set; }
        public int? JuniorAge { get; set; }
        public int AGBNumber { get; set; }

        public string Fee { get; set; }

        public string Declaration { get; set; }

        public string ShootingStoolChair { get; set; }
    }
}
