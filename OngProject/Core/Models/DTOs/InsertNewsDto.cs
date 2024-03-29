﻿using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertNewsDto
    {
        [Required(ErrorMessage = "El atributo debe ser string.")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public int CategoryId { get; set; } = 1;
    }
}
