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
        [Required]
        public string Title { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
