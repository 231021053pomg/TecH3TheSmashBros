using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3TheSmashBros.API.Models
{
    public class Roles : BaseModel
    {
        
        [Required]
        public string RoleName { get; set; }
    }
}
