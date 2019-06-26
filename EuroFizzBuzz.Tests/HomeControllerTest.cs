using System;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using EuroFizzBuzz.Controllers;
using EuroFizzBuzz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace EuroFizzBuzz.Tests
{
    public class HomeControllerFixture : IDisposable
    {
        public SqliteConnection Db { get; private set; }
        public EuroFizzBuzzContext Context { get; private set; }

        public HomeControllerFixture()
        {
            Db = new SqliteConnection("DataSource=:memory:");
            Db.Open();

            var options = new DbContextOptionsBuilder<EuroFizzBuzzContext>()
                    .UseSqlite(Db)
                    .Options;

            Context = new EuroFizzBuzzContext(options);
            
            Context.Database.EnsureCreated();
            
        }

        public void Dispose()
        {

            foreach (Submission submission in Context.Submissions)
            {
                Context.Submissions.Remove(submission);
            }

            Context.SaveChanges();

            Db.Close();
        }
    }

    public class HomeControllerTest : IClassFixture<HomeControllerFixture>
    {
        private readonly HomeControllerFixture _fixture;

        public HomeControllerTest(HomeControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TestHomeControllerReturnsCorrectView()
        {
            var controller = new HomeController(_fixture.Context);
            var result = controller.Index() as ViewResult;
            result.ViewData["Title"] = "Home";            
        }

        [Fact]
        public void TestHomeControllerReturnsDefaultSubmissionObject()
        {
            var controller = new HomeController(_fixture.Context);
            var result = controller.Index() as ViewResult;

            var expected = typeof(Submission);
            Assert.IsType(expected, result.Model);

            var submission = result.Model as Submission;
            Assert.Equal(1, submission.StartNumber);
            Assert.Equal(100, submission.EndNumber);
        }

        [Fact]
        public void TestHomeControllerWritesSubmissionModelToDatabase()
        {
            var controller = new HomeController(_fixture.Context);
            var result = controller.Index() as ViewResult;

            var options = new DbContextOptionsBuilder<EuroFizzBuzzContext>()
                .UseSqlite(_fixture.Db)
                .Options;

            using (var context = new EuroFizzBuzzContext(options))
            {
                var submissions = context.Submissions;
                Assert.True(submissions.Contains(result.Model as Submission));
            }
        }   
    }
}
