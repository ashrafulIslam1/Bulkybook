using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bulkybook.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastModifiedDate { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public int Status { get; set; }
        public int? CompanyId { get; set; }
    }
}
