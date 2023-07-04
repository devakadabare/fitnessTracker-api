using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public DateOnly DOB { get; set; }

        public ICollection<UserWorkout> UserWorkout { get; set; }
        public ICollection<WeightLog> WeightLog { get; set; }
        public ICollection<Prediction> Prediction { get; set; }
        public ICollection<UserWorkoutEnrollment> UserWorkoutEnrollment { get; set; }
    

    }
}