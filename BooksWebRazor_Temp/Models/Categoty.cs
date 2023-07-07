using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BooksWebRazor_Temp.Models
{
    public class Categoty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Order")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
