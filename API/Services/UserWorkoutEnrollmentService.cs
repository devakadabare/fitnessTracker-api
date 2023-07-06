using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    
    public class UserWorkoutEnrollmentService
    {
        private readonly StoreContext _context;
        private readonly WorkoutPlanService _workoutPlanService;

        public UserWorkoutEnrollmentService(StoreContext context, WorkoutPlanService workoutPlanService)
        {
            _context = context;
            _workoutPlanService = workoutPlanService;
            
        }

        //get user enrollments by userid
        public async Task<List<UserWorkoutEnrollment>> GetUserWorkoutEnrollmentsByUserIdAsync(int id)
        {
            return await _context.UserWorkoutEnrollments.Where(uwe => uwe.UserId == id).ToListAsync();
        }
        
        public async Task<UserWorkoutEnrollmentDataDTO> GetUserWorkoutEnrollmentByIdAsync(int id)
        {
            // return await _context.UserWorkoutEnrollments.FindAsync(id);
            var userWorkoutEnrollment = await _context.UserWorkoutEnrollments.FirstOrDefaultAsync(uwe => uwe.Id == id);

            if (userWorkoutEnrollment == null)
                return null;

            var workoutPlanId = userWorkoutEnrollment.WorkoutPlanId;

            var workoutPlan = await _workoutPlanService.GetWorkoutPlanWithWorkoutsByIdAsync(workoutPlanId);

            var userWorkoutEnrollmentDataDTO = new UserWorkoutEnrollmentDataDTO
            {
                Id = userWorkoutEnrollment.Id,
                Date = userWorkoutEnrollment.Date,
                UserId = userWorkoutEnrollment.UserId,
                WorkoutPlanId = userWorkoutEnrollment.WorkoutPlanId,
                Days = workoutPlan.WorkoutPlanItems.Count,
                CompletedDays = userWorkoutEnrollment.CompletedDays,
                StartDate = userWorkoutEnrollment.StartDate,
                Status = userWorkoutEnrollment.Status,
                workoutPlan = new List<WorkoutPlanWithItemsDTO> { workoutPlan }
            };

            return userWorkoutEnrollmentDataDTO;

           
        }

        public async Task<UserWorkoutEnrollment> CreateUserWorkoutEnrollmentAsync(UserWorkoutEnrollmentCreationDTO userWorkoutEnrollment)
        {
            
            var newUserWorkoutEnrollment = new UserWorkoutEnrollment
            {
                UserId = userWorkoutEnrollment.UserId,
                WorkoutPlanId = userWorkoutEnrollment.WorkoutPlanId,
                Date = userWorkoutEnrollment.Date,
                CompletedDays = userWorkoutEnrollment.CompletedDays,
                StartDate = userWorkoutEnrollment.StartDate,
                Status = "ACTIVE"
            };

            object value = _context.UserWorkoutEnrollments.Add(newUserWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return newUserWorkoutEnrollment;

        }

        //complete single day workout
        public async Task<UserWorkoutEnrollment> CompleteDayAsync(int Id)
        {
            var existingUserWorkoutEnrollment = await _context.UserWorkoutEnrollments.FindAsync(Id);
            
            // Update the properties of the existing user entity
            existingUserWorkoutEnrollment.CompletedDays = existingUserWorkoutEnrollment.CompletedDays + 1;

            _context.UserWorkoutEnrollments.Update(existingUserWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return existingUserWorkoutEnrollment;
        }


        public async Task<UserWorkoutEnrollment> UpdateUserWorkoutEnrollmentAsync(UserWorkoutEnrollmentUpdateDTO userWorkoutEnrollment)
        {
            var existingUserWorkoutEnrollment = await _context.UserWorkoutEnrollments.FindAsync(userWorkoutEnrollment.Id);

            // Update the properties of the existing user entity
            existingUserWorkoutEnrollment.CompletedDays = userWorkoutEnrollment.CompletedDays;
            existingUserWorkoutEnrollment.Status = userWorkoutEnrollment.Status;

            _context.UserWorkoutEnrollments.Update(existingUserWorkoutEnrollment);
            await _context.SaveChangesAsync();
            return existingUserWorkoutEnrollment;
        }
    }
}