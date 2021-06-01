using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3TheSmashBros.API.Models
{
    public class OrderDetail : BaseModel
    {

        [ForeignKey("Prodcuts.Id")]
        public string ProductsId { get; set; }

        public string Price { get; set; }

        [Required]
        public string Amount { get; set; }

        [ForeignKey("OrderNumber.Id")]
        public int OrderNumberId { get; set; }
    }
}
