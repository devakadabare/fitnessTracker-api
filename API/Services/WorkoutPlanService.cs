using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class WorkoutPlanService
    {
        private readonly StoreContext _context;

        public WorkoutPlanService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutPlan>> GetWorkoutPlansAsync()
        {
            return await _context.WorkoutPlans.ToListAsync();
        }
        public async Task<List<WorkoutPlan>> GetWorkoutPlansWithWorkoutsAsync()
        {
            return await _context.WorkoutPlans.Include(wp => wp.WorkoutPlanItems).ThenInclude(wpi => wpi.Workout).ToListAsync();
            
        }

        public async Task<WorkoutPlan> GetWorkoutPlanByIdAsync(int id)
        {
            return await _context.WorkoutPlans.FindAsync(id);
        }

        public async Task<WorkoutPlan> GetWorkoutPlanWithWorkoutsByIdAsync(int id)
        {
            return await _context.WorkoutPlans.Include(wp => wp.WorkoutPlanItems).ThenInclude(wpi => wpi.Workout).FirstOrDefaultAsync(wp => wp.Id == id);
        }

        public async Task<WorkoutPlan> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan)
        {
            _context.WorkoutPlans.Add(workoutPlan);
            await _context.SaveChangesAsync();
            return workoutPlan;
        }

        public async Task<WorkoutPlan> UpdateWorkoutPlanAsync(WorkoutPlan workoutPlan)
        {
            _context.WorkoutPlans.Update(workoutPlan);
            await _context.SaveChangesAsync();
            return workoutPlan;
        }

        public async Task<WorkoutPlan> DeleteWorkoutPlanAsync(int id)
        {
            var workoutPlan = await _context.WorkoutPlans.FindAsync(id);
            _context.WorkoutPlans.Remove(workoutPlan);
            await _context.SaveChangesAsync();
            return workoutPlan;
        }
        
    }
}