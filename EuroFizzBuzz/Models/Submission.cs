using System;
using Microsoft.EntityFrameworkCore;

namespace EuroFizzBuzz.Models
{
    public class EuroFizzBuzzContext : DbContext
    {
        public DbSet<Submission> Submissions { get; set; }

        public EuroFizzBuzzContext(DbContextOptions<EuroFizzBuzzContext> options)
            : base(options)
        { }
    }

    public class Submission
    {
        public int SubmissionId { get; set; }
        public int StartNumber { get; set; }
        public int EndNumber { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
