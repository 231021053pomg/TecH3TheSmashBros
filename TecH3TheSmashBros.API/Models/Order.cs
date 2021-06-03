using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecH3TheSmashBros.API.Models
{
    public class Order : BaseModel
    {

        [ForeignKey("Customer.Id")]
        public int UserId { get; set; }
        [Required]
        public int Date { get; set; }

    }
}
