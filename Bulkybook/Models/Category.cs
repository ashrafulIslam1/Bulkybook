
using System.ComponentModel.DataAnnotations; // We have to import this

namespace Bulkybook.Models
{
    public class Category
    {
        // Here I am using [Key] as Data Annotations, this means that Id is the primary Key of this Category table.
        [Key]  
        public int Id { get; set; }

        // Here I am using [Required] as Data Annotations, this means that Name is the required filed of this Category table.
        [Required]
        public string Name { get; set; }

        [System.ComponentModel.DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatDateTime { get; set; } = DateTime.Now;


    }
}
