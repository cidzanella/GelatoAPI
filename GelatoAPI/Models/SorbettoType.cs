using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Models
{
    public class SorbettoType
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
