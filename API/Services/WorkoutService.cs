using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class WorkoutService
    {
        private readonly StoreContext _context;

        public WorkoutService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetWorkoutsAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workouts.FindAsync(id);
        }

        public async Task<Workout> CreateWorkoutAsync(WorkoutCreationDTO workout)
        {

            var newWorkout = new Workout
            {
                Name = workout.Name,
                Description = workout.Description,
                MET = workout.MET
            };

            _context.Workouts.Add(newWorkout);
            await _context.SaveChangesAsync();

            return newWorkout;

        }

        public async Task<Workout> UpdateWorkoutAsync(WorkoutUpdateDTO workout)
        {
            var existingWorkout = await _context.Workouts.FindAsync(workout.Id);

            // Update the properties of the existing workout entity
            existingWorkout.Name = workout.Name;
            existingWorkout.Description = workout.Description;
            existingWorkout.MET = workout.MET;

            _context.Workouts.Update(existingWorkout);
            await _context.SaveChangesAsync();
            return existingWorkout;
        }

        public async Task<Workout> DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return workout;
        }
    }
}