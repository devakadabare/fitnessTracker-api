using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }

        //avg MET of all workouts in the plan
        public double MET { get; set; }

    }
}