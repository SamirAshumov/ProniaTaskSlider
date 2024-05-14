using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProniaTask.Core.Models
{
    public class Slider : BaseEntity
    {
        [Required]
        public string Sale { get; set; }

        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; } = null!;
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string? ButtonName { get; set; }
    }
}
