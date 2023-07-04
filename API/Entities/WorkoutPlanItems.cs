using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class WorkoutPlanItems
    {
        public int Id { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }
        
        [ForeignKey("WorkoutPlan")]
        public int WorkoutPlanId { get; set; }

        public Workout Workout { get; set; }

        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public int Order { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Rest { get; set; }
    }
}