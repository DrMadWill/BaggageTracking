using System.ComponentModel.DataAnnotations;

namespace BaggageTracking.Models
{
    public class Status
    {
        public Status()
        {
            Loadings = new HashSet<Baggage>();
            Landeds = new HashSet<Baggage>();
            IsOuts = new HashSet<Baggage>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(14)]
        public string ClassName { get; set; }

        [Required]
        public string Icon { get; set; }

        public ICollection<Baggage> Loadings { get; set; }
        public ICollection<Baggage> Landeds { get; set; }
        public ICollection<Baggage> IsOuts { get; set; }

    }
}
