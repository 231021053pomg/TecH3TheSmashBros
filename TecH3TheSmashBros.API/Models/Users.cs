using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3TheSmashBros.API.Models
{
    public class Users : BaseModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Maximum 32 Chars")]

        public string Email { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Maximum 32 Chars")]

        public string Password { get; set; }

        //[ForeignKey("")]
        public string UserType { get; set; }
    }
}
