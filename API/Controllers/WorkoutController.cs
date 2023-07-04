using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WorkoutController: ControllerBase
    {
        private readonly WorkoutService _workoutService;

        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Workout>>> GetWorkoutsAsync()
        {
            return await _workoutService.GetWorkoutsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkoutByIdAsync(int id)
        {
            return await _workoutService.GetWorkoutByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> CreateWorkoutAsync(Workout workout)
        {
            return await _workoutService.CreateWorkoutAsync(workout);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Workout>> UpdateWorkoutAsync(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            return await _workoutService.UpdateWorkoutAsync(workout);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Workout>> DeleteWorkoutAsync(int id)
        {
            return await _workoutService.DeleteWorkoutAsync(id);
        }

    }
}