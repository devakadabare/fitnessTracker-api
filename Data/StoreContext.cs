using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myFitnessTracker.Entities;

namespace myFitnessTracker.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }

}