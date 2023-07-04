using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MET { get; set; }

        public ICollection<WorkoutPlanItems> WorkoutPlanItems { get; set; }
        public ICollection<UserWorkout> UserWorkout { get; set; }

    }
}