using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class UserWorkoutEnrollmentCreationDTO
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int WorkoutPlanId { get; set; }
        public int Days { get; set; }
        public int CompletedDays { get; set; }
        public DateTime StartDate { get; set; }

    }
}
