using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class CheatMeal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Calories { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}