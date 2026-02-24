using Microsoft.EntityFrameworkCore;
using IssueTracker.Api.Models;
namespace IssueTracker.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Issue> Issues {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Issue>().HasData(

                new Issue
                {
                    Id = 1,
                    Name = "First Issue",
                    Description = "Fix the login button",
                    Status = "Open"
                },
             new Issue
             {
            Id = 2,
            Name = "Second Issue",
            Description = "Update the database schema",
            Status = "In Progress"
              },
             new Issue
             {
                 Id = 3,
                 Name = "Third Issue",
                 Description = "Update the database schema",
                 Status = "Done"

             }




                );

            

        }

}
}
