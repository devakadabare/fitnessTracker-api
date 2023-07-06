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
        public double TotalMET { get; set; }

        public ICollection<WorkoutPlanItems> WorkoutPlanItems { get; set; }
        public ICollection<UserWorkoutEnrollment> UserWorkoutEnrollment { get; set; }

    }
}