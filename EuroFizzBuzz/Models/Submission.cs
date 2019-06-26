﻿using System;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Start Number")]
        public int StartNumber { get; set; }

        [Display(Name = "End Number")]
        public int EndNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }
    }
}
