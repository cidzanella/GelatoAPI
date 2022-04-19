using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.DTOs
{
    public class BaseRecipeDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BaseTypeId { get; set; }

        [Required]
        public int RawMaterialId { get; set; }

        public RawMaterialDTO RawMaterial { get; set; }

        [Required]
        public int GramsPerKg { get; set; }

    }
}
