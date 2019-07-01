using System;
using System.Collections.Generic;

namespace EuroFizzBuzz.Models.Services
{
    public class FizzBuzzService
    {
        private readonly List<(int, string)> _factors;
        public string IsMultipleOfBothValue { get; set; }

        public FizzBuzzService(List<(int, string)> factors, string isMultipleOfBothValue = "Eurofins")
        {
            _factors = factors;
            IsMultipleOfBothValue = isMultipleOfBothValue;
        }

        public string GetFizzBuzzValue(int number)
        {
            bool multipleOfFirstFactor = number % _factors[0].Item1 == 0;
            bool multipleOfSecondFactor = number % _factors[1].Item1 == 0;

            if (multipleOfFirstFactor && multipleOfSecondFactor)
            {
                return IsMultipleOfBothValue;
            }

            if (multipleOfFirstFactor)
            {
                return _factors[0].Item2;
            }
            if (multipleOfSecondFactor)
            {
                return _factors[1].Item2;
            }

            return number.ToString();
        }
    }
}
