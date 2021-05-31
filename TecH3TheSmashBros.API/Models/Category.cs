using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TecH3TheSmashBros.API.Models
{
    public class Category : BaseModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryTitle { get; set; }
    }
}
