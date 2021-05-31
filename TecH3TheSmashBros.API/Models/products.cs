using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3TheSmashBros.API.Models
{
    public class Products : BaseModel
    {
        [Key]
        public int ProductId;

        public int ProductTitle { get; set; }

        public int MyProperty { get; set; }
    }
}
