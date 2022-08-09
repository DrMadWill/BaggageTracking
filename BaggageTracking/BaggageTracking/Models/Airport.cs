using System.ComponentModel.DataAnnotations.Schema;

namespace BaggageTracking.Models
{
    [Table("Airports")]
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Airport()
        {
            Platforms = new HashSet<Platform>();
            ToAirports = new HashSet<Ticket>();
        }

        public ICollection<Platform> Platforms { get; set; }
        public ICollection<Ticket> ToAirports { get; set; }
        public ICollection<Ticket> FromAirports { get; set; }
    }
}
