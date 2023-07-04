using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WorkoutPlanController: ControllerBase
    {
        private readonly WorkoutPlanService _workoutPlanService;

        public WorkoutPlanController(WorkoutPlanService workoutPlanService)
        {
            _workoutPlanService = workoutPlanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutPlan>>> GetWorkoutPlansAsync()
        {
            return await _workoutPlanService.GetWorkoutPlansAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutPlan>> GetWorkoutPlanByIdAsync(int id)
        {
            return await _workoutPlanService.GetWorkoutPlanByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutPlan>> CreateWorkoutPlanAsync(WorkoutPlan workoutPlan)
        {
            return await _workoutPlanService.CreateWorkoutPlanAsync(workoutPlan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutPlan>> UpdateWorkoutPlanAsync(int id, WorkoutPlan workoutPlan)
        {
            if (id != workoutPlan.Id)
            {
                return BadRequest();
            }

            return await _workoutPlanService.UpdateWorkoutPlanAsync(workoutPlan);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkoutPlan>> DeleteWorkoutPlanAsync(int id)
        {
            return await _workoutPlanService.DeleteWorkoutPlanAsync(id);
        }
    }
}