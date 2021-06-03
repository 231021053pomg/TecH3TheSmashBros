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

        public int Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [ForeignKey("Order.Id")]
        public int OrderId { get; set; }
    }
}
