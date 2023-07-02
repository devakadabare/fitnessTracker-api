using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFitnessTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Entities.Student[]
            {
                new Entities.Student{Name="Carson"},
                new Entities.Student{Name="Meredith"},
                new Entities.Student{Name="Arturo"},
                new Entities.Student{Name="Gytis"},
                new Entities.Student{Name="Yan"},
                new Entities.Student{Name="Peggy"},
                new Entities.Student{Name="Laura"},
                new Entities.Student{Name="Nino"}
            };
            foreach (Entities.Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}