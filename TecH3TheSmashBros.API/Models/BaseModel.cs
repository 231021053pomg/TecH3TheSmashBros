using System;
using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TecH3TheSmashBros.API.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateAt { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
    }
}
