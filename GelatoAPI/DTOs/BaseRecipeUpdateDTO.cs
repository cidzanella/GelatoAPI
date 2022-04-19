using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.DTOs
{
    public class BaseRecipeUpdateDTO
    {
        public int Id { get; set; }

        public int GramsPerKg { get; set; }
    }
}
