using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class DBData : DbContext
    {
        public DbSet<Request> Request { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<GeologicalSurvey> GeologicalSurvey { get; set; }

        public DBData(DbContextOptions<DBData> options) : base(options)
        {
            if (!Database.CanConnect())
            {
                Database.EnsureCreatedAsync();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new GeologicalSurveyConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
        }
    }
}
