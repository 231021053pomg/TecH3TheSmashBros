using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecH3TheSmashBros.API.Models
{
    public class User : BaseModel
    {

        [Required]
        [StringLength(64, ErrorMessage = "Maximum 64 Chars")]
        public string Email { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Maximum 32 Chars")]
        public string Password { get; set; }

        [ForeignKey("Role.Id")]
        public int RoleId { get; set; } = 1;

        public List<Customer>Customer{ get; set; }
    }
}
