using System;
using Microsoft.Data.Sqlite;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EuroFizzBuzz.Models;
using Xunit;


namespace EuroFizzBuzz.Tests
{
    public class SubmissionModelTest
    {
        [Fact]
        public void TestCreateSubmissionSuccessfully()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<EuroFizzBuzzContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new EuroFizzBuzzContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new EuroFizzBuzzContext(options))
                {
                    var submission = new Submission();
                    submission.StartNumber = 0;
                    submission.EndNumber = 100;
                    submission.Timestamp = DateTime.Now;

                    context.Submissions.Add(submission);
                    context.SaveChanges();
                }

                using (var context = new EuroFizzBuzzContext(options))
                {

                    Assert.Equal(1, context.Submissions.Count());
                    Assert.Equal(0, context.Submissions.First().StartNumber);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
