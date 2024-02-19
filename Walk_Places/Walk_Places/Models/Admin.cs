using System.ComponentModel.DataAnnotations;

namespace Walk_Places.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
