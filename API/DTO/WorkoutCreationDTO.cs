using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class WorkoutCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MET { get; set; }
    }
}