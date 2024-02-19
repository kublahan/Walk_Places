using System.ComponentModel.DataAnnotations;

namespace Walk_Places.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
}
