using GelatoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.DTOs
{
    // sorbetto item on the recipe
    public class SorbettoRecipeDTO
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
