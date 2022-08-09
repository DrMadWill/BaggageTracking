using System.ComponentModel.DataAnnotations.Schema;

namespace BaggageTracking.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Baggage Baggage { get; set; }
        public Airport FromAirport { get; set; }
        public int FromAirportId { get; set; }

        public Airport ToAirport { get; set; }
        public int ToAirportId { get; set; }

        public DateTime FlyDate { get; set; } = DateTime.Now;
        public string FlyCode { get; set; }

    }
}
