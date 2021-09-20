using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Models
{
    public class RawMaterialType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
