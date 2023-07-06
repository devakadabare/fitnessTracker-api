
using System.Collections.Generic;
using API.Entities;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if(context.Workouts.Any() || context.WorkoutPlans.Any() || context.WorkoutPlanItems.Any() || context.CheatMeals.Any() || context.Users.Any() || context.UserWorkout.Any() || context.UserWorkoutEnrollments.Any() )
            {
                return;
            }
            


            var workouts = new List<Workout>(){
                new Workout { Id = 1, Name = "Workout 1", Description = "This is workout 1", MET = 4.0 },
                new Workout { Id = 2, Name = "Workout 2", Description = "This is workout 2", MET = 5.0 },
                new Workout { Id = 3, Name = "Workout 3", Description = "This is workout 3", MET = 6.0 },
                new Workout { Id = 4, Name = "Workout 4", Description = "This is workout 4", MET = 7.0 }
            };

            var workoutPlans = new List<WorkoutPlan>(){
                new WorkoutPlan { Id = 1, Name = "Beginner", Difficulty = "Easy", TotalMET = 4.0 },
                new WorkoutPlan { Id = 2, Name = "Intermediate", Difficulty = "Medium", TotalMET = 5.0 },
                new WorkoutPlan { Id = 3, Name = "Weight Loss", Difficulty = "Hard", TotalMET = 6.0 },
                new WorkoutPlan { Id = 4, Name = "Mussel Pump", Difficulty = "Hard", TotalMET = 7.0 }
            };

            var workoutPlanItems = new List<WorkoutPlanItems>(){
                new WorkoutPlanItems { Id = 1, WorkoutId = 1, WorkoutPlanId = 1, Order = 1, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 2, WorkoutId = 2, WorkoutPlanId = 1, Order = 2, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 3, WorkoutId = 3, WorkoutPlanId = 1, Order = 3, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 4, WorkoutId = 4, WorkoutPlanId = 1, Order = 4, Sets = 3, Reps = 10, Rest = 60 },

                new WorkoutPlanItems { Id = 5, WorkoutId = 1, WorkoutPlanId = 2, Order = 1, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 6, WorkoutId = 2, WorkoutPlanId = 2, Order = 2, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 7, WorkoutId = 3, WorkoutPlanId = 2, Order = 3, Sets = 3, Reps = 10, Rest = 60 },

                new WorkoutPlanItems { Id = 8, WorkoutId = 1, WorkoutPlanId = 3, Order = 1, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 9, WorkoutId = 2, WorkoutPlanId = 3, Order = 2, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 10, WorkoutId = 3, WorkoutPlanId = 3, Order = 3, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 11, WorkoutId = 4, WorkoutPlanId = 3, Order = 4, Sets = 3, Reps = 10, Rest = 60 },

                new WorkoutPlanItems { Id = 12, WorkoutId = 1, WorkoutPlanId = 4, Order = 1, Sets = 3, Reps = 10, Rest = 60 },
                new WorkoutPlanItems { Id = 13, WorkoutId = 2, WorkoutPlanId = 4, Order = 2, Sets = 3, Reps = 10, Rest = 60 },
            };

            var cheatMeals = new List<CheatMeal>(){
                new CheatMeal { Id = 1, Name = "Pizza", Description = "This is cheat meal 1", Calories = 1000, Type = "Fast Food" },
                new CheatMeal { Id = 2, Name = "Burger", Description = "This is cheat meal 2", Calories = 2000, Type = "Fast Food" },
                new CheatMeal { Id = 3, Name = "Fried Rice", Description = "This is cheat meal 3", Calories = 3000, Type = "Fast Food" },
            };

            var users = new List<User>(){
                new User { Id = 1, Name = "User 1", Email = "devakadabare1@gmail.com", PasswordHash = "123456", Height = "5'10", Weight = 70.0, DOB = new System.DateOnly(1997, 10, 10) },
            };

            var userWorkouts = new List<UserWorkout>(){
                new UserWorkout { Id = 1, UserId = 1, WorkoutId = 1, Date = new System.DateOnly(2022, 10, 10), Duration = 60, CaloriesBurned = 1000 },
                new UserWorkout { Id = 2, UserId = 1, WorkoutId = 2, Date = new System.DateOnly(2022, 10, 11), Duration = 60, CaloriesBurned = 1000 },
                new UserWorkout { Id = 3, UserId = 1, WorkoutId = 3, Date = new System.DateOnly(2022, 10, 12), Duration = 60, CaloriesBurned = 1000 },
                new UserWorkout { Id = 4, UserId = 1, WorkoutId = 4, Date = new System.DateOnly(2022, 10, 13), Duration = 60, CaloriesBurned = 1000 },
            };

            var userWorkoutEnrollments = new List<UserWorkoutEnrollment>(){
                new UserWorkoutEnrollment { Id = 1, UserId = 1, WorkoutPlanId = 1, Days = 30, Status="ACTIVE" },
                new UserWorkoutEnrollment { Id = 2, UserId = 1, WorkoutPlanId = 2, Days = 30, Status="INACTIVE" },
                new UserWorkoutEnrollment { Id = 3, UserId = 1, WorkoutPlanId = 3, Days = 30, Status="INACTIVE" },
                new UserWorkoutEnrollment { Id = 4, UserId = 1, WorkoutPlanId = 4, Days = 30, Status="INACTIVE" },
            };


            context.Workouts.AddRange(workouts);
            context.WorkoutPlans.AddRange(workoutPlans);
            context.WorkoutPlanItems.AddRange(workoutPlanItems);
            context.CheatMeals.AddRange(cheatMeals);
            context.Users.AddRange(users);
            context.UserWorkout.AddRange(userWorkouts);
            context.UserWorkoutEnrollments.AddRange(userWorkoutEnrollments);

            context.SaveChanges();
        }
    }
}