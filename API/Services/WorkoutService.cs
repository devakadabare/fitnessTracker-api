using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Workout> CreateWorkoutAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }

        public async Task<Workout> UpdateWorkoutAsync(Workout workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
            return workout;
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