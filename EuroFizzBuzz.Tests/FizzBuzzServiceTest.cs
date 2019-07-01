using System;
using Xunit;
using EuroFizzBuzz.Models.Services;
using System.Collections.Generic;

namespace EuroFizzBuzz.Tests
{
    public class FizzBuzzServiceTest
    {
        [Theory]
        [InlineData(21, "Three")]
        [InlineData(20, "Five")]
        [InlineData(30, "Eurofins")]
        [InlineData(4, "4")]
        public void TestFizzBuzzServiceModifiesOutputForMultiples(int multiple, string expectedValue)
        {
            var factors = new List<(int, string)>
            {
                (3, "Three"),
                (5, "Five")
            };

            FizzBuzzService service = new FizzBuzzService(factors);

            var result = service.GetFizzBuzzValue(multiple);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void TestSetIsMultipleOfBothValueChangesValue()
        {
            var factors = new List<(int, string)>
            {
                (3, "Three"),
                (5, "Five")
            }; 
            FizzBuzzService service = new FizzBuzzService(factors, "New Value");

            Assert.Equal("New Value", service.IsMultipleOfBothValue);
        }
    }
}
