using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext: DbContext
    {
        //constructor
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {
            
        }

        //DbSet
        public DbSet<User> Users { get; set; }
    
    }
}