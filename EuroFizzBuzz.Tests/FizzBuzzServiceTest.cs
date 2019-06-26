using System;
using Xunit;
using EuroFizzBuzz.Models.Services;

namespace EuroFizzBuzz.Tests
{
    public class FizzBuzzServiceTest
    {
        // TODO: Use Theory
        [Theory]
        [InlineData(21, "Three")]
        [InlineData(15, "Five")]
        [InlineData(30, "Eurofins")]
        public void TestFizzBuzzServiceModifiesOutputForMultiples(int multiple, string expectedValue)
        {
            int[] multiples = { 3, 5 };

            FizzBuzzService service = new FizzBuzzService(multiples);

            var result = service.GetFizzBuzzValue(multiple);

            Assert.Equal(expectedValue, result);
        }

    }
}
