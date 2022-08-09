using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaggageTracking.Models
{
    [Table("Baggages")]
    public class Baggage
    {
        [Key, ForeignKey("Tickets")]
        public int Id { get; set; }
        public Ticket Ticket { get; set; }

        public Status Loading { get; set; }
        public int LoadingId { get; set; }

        public Status Landed { get; set; }
        public int LandedId { get; set; }

        public Status IsOut { get; set; }
        public int IsOutId { get; set; }

        public Platform OutPlatform { get; set; }
        public int? OutPlatformId { get; set; }

        public float Weight { get; set; }
    }
}
