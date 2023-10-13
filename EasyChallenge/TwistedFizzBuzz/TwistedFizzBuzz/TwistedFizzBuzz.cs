using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TwistedFizzBuzz
{
    public class TwistedFizzBuzz
    {
        private const string API_URL = "https://rich-red-cocoon-veil.cyclic.app/random";

        private const int NUMBER_THREE = 3;

        private const int NUMBER_FIVE = 5;

        private Dictionary<int, string> DefaultDivisorsAndMessage = new Dictionary<int, string>()
        {
            { NUMBER_THREE, "Fizz" },
            { NUMBER_FIVE, "Buzz" }
        };


        public List<string> OriginalFizzProblem()
        {
            List<string> myResultNumbers = new List<string>();

            for (int currentNumber = 1; currentNumber <= 100; currentNumber++)
            {
                DoGenericFizzProblem(myResultNumbers, currentNumber, DefaultDivisorsAndMessage);
            }

            return myResultNumbers;
        }

        public List<string> NonSequentialSetOfNumbers(int[] numbers)
        {
            return AlternativeTokensWithNonSequentialNumbers(numbers, DefaultDivisorsAndMessage);
        }

        public List<string> AlternativeTokensWithNonSequentialNumbers(int[] numbers, Dictionary<int, string> divisorsAndMessage)
        {
            List<string> myResultNumbers = new List<string>();

            foreach (int currentNumber in numbers)
            {
                DoGenericFizzProblem(myResultNumbers, currentNumber, divisorsAndMessage);
            }

            return myResultNumbers;
        }


        public List<string> RangeOfNumbers(int numberOne, int numberTwo)
        {
            return RangeOfNumbersWithAlternativeTokens(numberOne, numberTwo, DefaultDivisorsAndMessage);
        }

        public List<string> RangeOfNumbersWithAlternativeTokens(int numberOne, int numberTwo, Dictionary<int, string> divisorsAndMessage)
        {
            List<string> myResultNumbers = new List<string>();

            int bigger, lower;

            if (numberTwo > numberOne)
            {
                bigger = numberTwo;
                lower = numberOne;
            }
            else
            {
                bigger = numberOne;
                lower = numberTwo;
            }

            for (int currentNumber = lower; currentNumber <= bigger; currentNumber++)
            {
                DoGenericFizzProblem(myResultNumbers, currentNumber, divisorsAndMessage);
            }

            return myResultNumbers;
        }

        public List<string> GenerateTokensFromApi(int[] numbers)
        {
            // not creating a Automatic Test
            var request = WebRequest.Create(API_URL);
            request.Method = "GET";

            WebResponse webResponse = request.GetResponse();

            Stream webStream = webResponse.GetResponseStream();

            StreamReader reader = new StreamReader(webStream);
            string json = reader.ReadToEnd();

            ObjectForApi messageFromApi = JsonConvert.DeserializeObject<ObjectForApi>(json);

            Dictionary<int, string> divisorsAndMessagesFromApi = new Dictionary<int, string>()
            {
                { messageFromApi.Multiple, messageFromApi.Word }
            };

            List<string> myResultNumbers = new List<string>();

            foreach (int currentNumber in numbers)
            {
                DoGenericFizzProblem(myResultNumbers, currentNumber, divisorsAndMessagesFromApi);
            }

            return myResultNumbers;
        }

        public void DisplayAllTheLines(List<string> messages)
        {
            messages.ForEach(msg => Console.WriteLine(msg));

            Console.ReadKey();
        }

        private void DoGenericFizzProblem(List<string> myList, int currentNumber, Dictionary<int, string> divisorsAndMessage)
        {
            string message = string.Empty;

            foreach (KeyValuePair<int, string> item in divisorsAndMessage)
            {
                message += ReturnTheMessageWhatIWantIfItContains(currentNumber, item.Key, item.Value);
            }

            if (string.IsNullOrEmpty(message))
            {
                message = currentNumber.ToString();
            }

            myList.Add(message);
        }

        private string ReturnTheMessageWhatIWantIfItContains(int currentNumber, int number, string message)
        {
            if (currentNumber % number == 0)
            {
                return message;
            }

            return string.Empty;
        }
    }

    public class ObjectForApi
    {
        public int Multiple { get; set; }

        public string Word { get; set; }
    }
}
