using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.DTO
{
    public class WorkoutPlanWithItemsDTO
    {
        public int Id { get; set; }
            public string Name { get; set; }
            public string Difficulty { get; set; }
            public double TotalMET { get; set; }
            // public List<WorkoutDTO> Workouts { get; set; }

            public List<WorkoutPlanItemDTO> WorkoutPlanItems { get; set; }
        
    }
    
}