﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Member : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string FacebookUrl { get; set; }

        [StringLength(255)]
        public string InstagramUrl { get; set; }

        [StringLength(255)]
        public string LinkedinUrl { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
