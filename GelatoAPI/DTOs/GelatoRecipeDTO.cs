using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.DTOs
{
    public class GelatoRecipeDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        [Required]
        public int BaseTypeId { get; set; }

        public BaseTypeDTO BaseType { get; set; }

        [Required]
        public int BaseInGrams { get; set; }

        public int PastaAId { get; set; }

        public RawMaterialDTO PastaA { get; set; }

        public int PastaAInGrams { get; set; }

        public int PastaBId { get; set; }

        public RawMaterialDTO PastaB { get; set; }

        public int PastaBInGrams { get; set; }

        public int VariegatoAId { get; set; }

        public RawMaterialDTO VariegatoA { get; set; }

        public int VariegatoAInGrams { get; set; }

        public int VariegatoBId { get; set; }

        public RawMaterialDTO VariegatoB { get; set; }

        public int VariegatoBInGrams { get; set; }

        public int ExtractionLayers { get; set; }

        public int MinimumStockLevel { get; set; }

        public double GelatoCost { get; set; } //based on last raw material prices

        public DateTime GelatoCostDate { get; set; } //date when cost was calculated

    }
}
