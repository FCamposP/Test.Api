using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts;
using Test.Domain.Entities.Common;

namespace Test.Domain.Entities
{
    [Table("MarcaAuto")]
    [PrimaryKey(nameof(MarcaAutoId))]
    public class MarcaAuto: AuditableEntity, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Column("MarcaAutoId")]
        public int MarcaAutoId { get; set; }
        [Required]
        [MaxLength(10)]
        public string? Codigo { get; set; }

        [MaxLength(250)]
        public string? Nombre { get; set; }

        [MaxLength(500)]
        public string? Descripcion { get; set; }
    }
}
