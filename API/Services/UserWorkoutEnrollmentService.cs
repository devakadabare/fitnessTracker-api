using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    
    public class UserWorkoutEnrollmentService
    {
        private readonly StoreContext _context;

        public UserWorkoutEnrollmentService(StoreContext context)
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
    }
}