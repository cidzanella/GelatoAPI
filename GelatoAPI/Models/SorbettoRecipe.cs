using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Models
{
    // sorbetto item on the recipe
    public class SorbettoRecipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SorbettoTypeId { get; set; }

        [Required]
        public int RawMaterialId { get; set; }
        
        public RawMaterial RawMaterial { get; set; }

        [Required]
        public int GramsPerKg { get; set; }

    }
}
