using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.DTO;

namespace API.Services
{
    public class ReportService
    {
        private readonly StoreContext _context;

        public ReportService(StoreContext context)
        {
            _context = context;
        }


        public async Task<List<ReportDTO>> GetReportByUserIdAsync(int userId)
        {
            //get user workout enrollments by userid
            var userWorkoutEnrollments = await _context.UserWorkoutEnrollments.Where(uwe => uwe.UserId == userId).ToListAsync();

            //create list of ReportDTO using userWorkoutEnrollments
            var reportData = new List<ReportDTO>();

            foreach (var userWorkoutEnrollment in userWorkoutEnrollments)
            {
                var workoutPlanId = userWorkoutEnrollment.WorkoutPlanId;

                var workoutPlan = await _context.WorkoutPlans.Include(wp => wp.WorkoutPlanItems).ThenInclude(wpi => wpi.Workout).FirstOrDefaultAsync(wp => wp.Id == workoutPlanId);

                var reportDTO = new ReportDTO
                {
                    Date = userWorkoutEnrollment.Date,
                    WorkoutPlanId = userWorkoutEnrollment.WorkoutPlanId,
                    WorkoutPlanName = workoutPlan.Name,
                    Days = workoutPlan.WorkoutPlanItems.Count,
                    CompletedDays = userWorkoutEnrollment.CompletedDays,
                    StartDate = userWorkoutEnrollment.StartDate,
                   
                };

                reportData.Add(reportDTO);
            }

            return reportData;
            
        }

    }
}