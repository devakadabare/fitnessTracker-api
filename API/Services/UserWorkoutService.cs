using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserWorkoutService
    {
        private readonly StoreContext _context;

        public UserWorkoutService(StoreContext context)
        {
            _context = context;
        }

        //get user workouts by userid
        public async Task<List<UserWorkout>> GetUserWorkoutsByUserIdAsync(int id)
        {
            return await _context.UserWorkouts.Where(uw => uw.UserId == id).ToListAsync();
        }

        public async Task<UserWorkout> GetUserWorkoutByIdAsync(int id)
        {
            return await _context.UserWorkouts.FindAsync(id);
        }

        public async Task<UserWorkout> CreateUserWorkoutAsync(UserWorkout userWorkout)
        {
            object value = _context.UserWorkouts.Add(userWorkout);
            await _context.SaveChangesAsync();
            return userWorkout;
        }

        public async Task<UserWorkout> UpdateUserWorkoutAsync(UserWorkout userWorkout)
        {
            _context.UserWorkouts.Update(userWorkout);
            await _context.SaveChangesAsync();
            return userWorkout;
        }

        public async Task<UserWorkout> DeleteUserWorkoutAsync(int id)
        {
            var userWorkout = await _context.UserWorkouts.FindAsync(id);
            _context.UserWorkouts.Remove(userWorkout);
            await _context.SaveChangesAsync();
            return userWorkout;
        }
    }
}