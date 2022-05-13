using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.DTOs
{
    // sorbetto item on the recipe
    public class SorbettoRecipeCreateDTO
    {
        [Required]
        public int SorbettoTypeId { get; set; }

        [Required]
        public int RawMaterialId { get; set; }

        [Required]
        public int GramsPerKg { get; set; }

    }
}
