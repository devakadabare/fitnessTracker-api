using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace API.Entities
{
    public class UserWorkout
    {
        public int Id { get; set; }

        public Workout Workout { get; set; }
        public User User { get; set; }

        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateOnly Date { get; set; }

        public int? Duration { get; set; }

        public int? Count { get; set; }

        public int? CaloriesBurned { get; set; }
    }
}