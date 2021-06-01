using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecH3TheSmashBros.API.Models
{
    public class Image : BaseModel
    {
        [Required]
        public string ImageName { get; set; }
        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }
    }
}
