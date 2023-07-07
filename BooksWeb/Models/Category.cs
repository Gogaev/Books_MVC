﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Order")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
