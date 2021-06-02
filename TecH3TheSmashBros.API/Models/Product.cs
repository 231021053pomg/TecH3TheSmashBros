using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3TheSmashBros.API.Models
{
    public class Product : BaseModel
    {
        [Required]
        [StringLength(64, ErrorMessage = "Less Than 64")]
        public string Title { get; set; }

        [Required]
        public int Storage { get; set; }

        [ForeignKey("Category.Id")]
        public int CategoryId { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
