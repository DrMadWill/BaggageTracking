using System.ComponentModel.DataAnnotations.Schema;

namespace BaggageTracking.Models
{
    [Table("Platforms")]
    public class Platform
    {
        public Platform()
        {
            OutBaggages = new HashSet<Baggage>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BaggageOutPoint { get; set; }

        public Airport Airport { get; set; }
        public int AirportId { get; set; }

        public ICollection<Baggage> OutBaggages { get; set; }
    }
}
