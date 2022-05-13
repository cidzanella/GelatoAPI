using System.ComponentModel.DataAnnotations;

namespace GelatoAPI.DTOs
{
    public class SorbettoTypeCreateDTO
    {

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public int? MinimumStockLevel { get; set; }

    }
}
