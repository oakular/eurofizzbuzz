using System;
using Xunit;
using EuroFizzBuzz.Models.Services;

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
            int[] factors = { 3, 5 };

            FizzBuzzService service = new FizzBuzzService(factors);

            var result = service.GetFizzBuzzValue(multiple);

            Assert.Equal(expectedValue, result);
        }

    }
}
