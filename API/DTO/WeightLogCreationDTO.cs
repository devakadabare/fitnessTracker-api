using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class WeightLogCreationDTO
    {
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
    }
}