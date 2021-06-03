using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecH3TheSmashBros.API.Models
{
    public class Customer : BaseModel
    {

        [Required]
        [StringLength(32, ErrorMessage = "Maximum 32 Chars")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Maximum 32 Chars")]
        public string LastName { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Maximum 64 Chars")]
        public string Street { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Maximum 16 Chars")]
        public int Zipcode { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Maximum 64 Chars")]
        public string City { get; set; }

        [ForeignKey("User.Id")]
        public int UserId { get; set; }
    }
}
