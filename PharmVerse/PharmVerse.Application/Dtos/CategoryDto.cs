using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Application.Dtos
{
    public class CategoryDto
    {
        public Int64 Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
