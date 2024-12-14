using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Domain.Entities.Common
{
    public abstract class AuditableEntity
    {
        [Required]
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

        [Required]
        [JsonIgnore]
        public DateTime Created { get; set; }

        [Required]
        [JsonIgnore]
        public int CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? Modified { get; set; }

        [JsonIgnore]
        public int? ModifiedBy { get; set; }
    }
}
