using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.DTOs
{
    public class BaseRecipeCreateDTO
    {

        public int BaseTypeId { get; set; }

        public int RawMaterialId { get; set; }

        public int GramsPerKg { get; set; }

    }
}
