using System;

namespace EuroFizzBuzz.Models.Services
{
    public class FizzBuzzService
    {
        protected int[] Factors { get; private set; }

        public FizzBuzzService(int[] factors)
        {
            Factors = factors;
        }

        public string GetFizzBuzzValue(int number)
        {
            bool multipleOfFirstFactor = number % Factors[0] == 0;
            bool multipleOfSecondFactor = number % Factors[1] == 0;

            if (multipleOfFirstFactor && multipleOfSecondFactor)
            {
                return "Eurofins";
            }

            if (multipleOfFirstFactor)
            {
                return "Three";
            }
            if (multipleOfSecondFactor)
            {
                return "Five";
            }

            return number.ToString();
        }
    }
}
