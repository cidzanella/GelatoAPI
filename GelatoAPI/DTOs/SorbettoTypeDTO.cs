using System;
using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.DTOs
{
    public class SorbettoTypeDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public int? MinimumStockLevel { get; set; }

        public double? SorbettoCost { get; set; } //based on last raw material prices

        public DateTime? SorbettoCostDate { get; set; } //date when cost was calculated

    }
}
