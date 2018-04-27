using Microsoft.EntityFrameworkCore;
 
namespace retake.Models
{
    public class retakeContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public retakeContext(DbContextOptions<retakeContext> options) : base(options) { }

	public DbSet<User> users {get; set;}
    public DbSet<ActivityModel> events {get; set;}
    public DbSet<Joiner> joiners {get; set;}
    }
}