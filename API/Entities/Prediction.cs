using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Prediction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}