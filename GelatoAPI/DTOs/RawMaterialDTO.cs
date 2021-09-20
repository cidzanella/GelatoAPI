using GelatoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.DTOs
{
    public class RawMaterialDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int SupplierId { get; set; }
        
        public RawMaterialSupplier Supplier { get; set; }

        public int TypeId { get; set; }

        public RawMaterialType Type { get; set; }

        public bool Active { get; set; }
    }
}
