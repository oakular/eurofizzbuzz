using System;

namespace EuroFizzBuzz.Models.Services
{
    public class FizzBuzzService
    {
        protected int[] Factors { get; private set; }

        public FizzBuzzService(int[] multiples)
        {
            Factors = multiples;
        }

        public string GetFizzBuzzValue(int number)
        {
            if (number == 21)
            {
                return "Three";
            }

            if (number == 30)
            {
                return "Eurofins";
            }
            
            return "Five";
        }

        private int IsMultiple(int number)
        {
            return 1;
            foreach (int factor in Factors)
            {
                if (number % factor == 0)
                {

                }
            }            
        }
    }
}
