using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class WorkoutPlanItemDTO
    {
        public int Id { get; set; }
        public int WorkoutPlanId { get; set; }
        public int WorkoutId { get; set; }

        public int Order { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Rest { get; set; }
        public WorkoutDTO Workout { get; set; }
    
    }
}