using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class UserWorkoutEnrollmentController: ControllerBase
    {
        private readonly ILogger<UserWorkoutEnrollmentController> _logger;
        private readonly UserWorkoutEnrollmentService _userWorkoutEnrollmentService;
        private readonly PredictionService _predictionService;

        public UserWorkoutEnrollmentController(PredictionService predictionService, UserWorkoutEnrollmentService userWorkoutEnrollmentService, ILogger<UserWorkoutEnrollmentController> logger)
        {
            _logger = logger;
            _userWorkoutEnrollmentService = userWorkoutEnrollmentService;
            _predictionService = predictionService;
        }

        [HttpGet("user/{userId}")]
        public async Task<List<UserWorkoutEnrollment>> Get(int userId)
        {
            //get all user workout enrollments from the database
            return await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentsByUserIdAsync(userId);
        }

        [HttpGet("single/{id}")]
        public async Task<UserWorkoutEnrollment> GetEnrollmentById(int id)
        {
            //get all user workout enrollments from the database
            return await _userWorkoutEnrollmentService.GetUserWorkoutEnrollmentByIdAsync(id);
        }

        //add a new user workout enrollment
        [HttpPost("single")]
        public async Task<ActionResult<UserWorkoutEnrollment>> Post(UserWorkoutEnrollmentCreationDTO userWorkoutEnrollment)
        {
            //create a new user workout enrollment
            var result = await _userWorkoutEnrollmentService.CreateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
            var userId = userWorkoutEnrollment.UserId;

            //create a new prediction
            var predictionResult = await _predictionService.CreatePredictionAsync(userId);
            return result; 
            
        }

        //update a user workout enrollment
        [HttpPut("single")]
        public async Task<ActionResult<UserWorkoutEnrollment>> Put(UserWorkoutEnrollmentUpdateDTO userWorkoutEnrollment)
        {
            //update a user workout enrollment
            var result = await _userWorkoutEnrollmentService.UpdateUserWorkoutEnrollmentAsync(userWorkoutEnrollment);
            return result; 
            
        }

        //complete single day workout
        [HttpPut("complete/{id}")]
        public async Task<ActionResult<UserWorkoutEnrollment>> CompleteDay(int id)
        {
            //complete a single day workout
            var result = await _userWorkoutEnrollmentService.CompleteDayAsync(id);
            return result; 
            
        }

        //delete a user workout enrollment
        // [HttpDelete]
        // public async Task<ActionResult<UserWorkoutEnrollment>> Delete(int id)
        // {
        //     //delete a user workout enrollment
        //     var result = await _userWorkoutEnrollmentService.DeleteUserWorkoutEnrollmentAsync(id);
        //     return result; 
            
        // }

    }
}