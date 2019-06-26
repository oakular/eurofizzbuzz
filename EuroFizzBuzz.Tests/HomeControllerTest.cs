using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using EuroFizzBuzz.Controllers;
using EuroFizzBuzz.Models;

namespace EuroFizzBuzz.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void TestHomeControllerReturnsCorrectView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            result.ViewData["Title"] = "Home";            
        }

        [Fact]
        public void TestHomeControllerReturnsDefaultSubmissionObject()
        {
            var controller = new HomeController();
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

        }
    }
}
