using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Models
{
    
    public class RawMaterial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public RawMaterialSupplier Supplier { get; set; }

        [Required]
        public int TypeId { get; set; }

        public RawMaterialType Type { get; set; }

        public bool Active { get; set; }
    }
}
