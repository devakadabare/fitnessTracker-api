using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class UserWorkoutEnrollment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        //workout plan
        public WorkoutPlan WorkoutPlan { get; set; }

        [ForeignKey("WorkoutPlan")]
        public int WorkoutPlanId { get; set; }
        public int Days { get; set; }
        public int CompletedDays { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }

    }
}