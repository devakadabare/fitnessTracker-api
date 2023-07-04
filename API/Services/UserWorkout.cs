using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserWorkout
    {
        private readonly StoreContext _context;

        public UserWorkout(StoreContext context)
        {
            _context = context;
        }

        //get user enrollments by userid
        public async Task<List<UserWorkoutEnrollment>> GetUserWorkoutEnrollmentsByUserIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.Where(uwe => uwe.UserId == id).ToListAsync();
        }

        public async Task<UserWorkoutEnrollment> GetUserWorkoutEnrollmentByIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.FindAsync(id);
        }

        public async Task<UserWorkoutEnrollment> CreateUserWorkoutEnrollmentAsync(UserWorkoutEnrollment userWorkoutEnrollment)
        {
            object value = _context.UserWorkoutEnrollments.Add(userWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return userWorkoutEnrollment;
        }

        public async Task<UserWorkoutEnrollment> UpdateUserWorkoutEnrollmentAsync(UserWorkoutEnrollment userWorkoutEnrollment)
        {
            _context.UserWorkoutEnrollments.Update(userWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return userWorkoutEnrollment;
        }

        public async Task<UserWorkoutEnrollment> DeleteUserWorkoutEnrollmentAsync(int id)
        {
            var userWorkoutEnrollment = await _context.UserWorkoutEnrollments.FindAsync(id);
            _context.UserWorkoutEnrollments.Remove(userWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return userWorkoutEnrollment;
        }
    }
}