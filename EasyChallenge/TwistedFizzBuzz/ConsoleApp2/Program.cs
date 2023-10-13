using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwistedFizzBuzz;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            TwistedFizzBuzz.TwistedFizzBuzz twisted = new TwistedFizzBuzz.TwistedFizzBuzz();

            //twisted.RangeOfNumbers(-20, 127);

            Dictionary<int, string> divisorsAndMessage = new Dictionary<int, string>()
            {
                { 5, "Fizz" },
                { 9, "Buzz" },
                { 27, "Bar"}
            };

            //twisted.GenerateTokensFromApi(new int [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});

            List<string> myResult = twisted.RangeOfNumbersWithAlternativeTokens(-20, 127, divisorsAndMessage);

            twisted.DisplayAllTheLines(myResult);
        }
    }
}
