using Microsoft.EntityFrameworkCore;

namespace StortfordArchers.Models
{
    public class CommitteeDetails
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public string MemberName { get; set; }

        public string Email { get; set; }
    }

    public class StortfordArchersDbContext : DbContext
    {
        public DbSet<CommitteeDetails> CommitteeDetails { get; set; }

        public StortfordArchersDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommitteeDetails>();
        }
    }
}