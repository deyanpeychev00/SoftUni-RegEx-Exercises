using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.__Valid_Usernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var splitSymbols = new char[] { ' ', '\\', '/', '(', ')', '\t' };
            var input = Console.ReadLine().Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
            var pattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}";
            var regex = new Regex(pattern);

            var usernames = GetValidUsernames(input, regex);
            var maxSum = int.MinValue;
            var firstUsername = "";
            var secondUsername = "";
            for (int i = 1; i < usernames.Count; i++)
            {
                var currentSum = usernames[i].Length + usernames[i - 1].Length;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    firstUsername = usernames[i - 1];
                    secondUsername = usernames[i];
                }
            }

            Console.WriteLine(firstUsername);
            Console.WriteLine(secondUsername);

        }

        private static List<string> GetValidUsernames(string[] input, Regex regex)
        {
            var usernames = new List<string>();
            foreach (var username in input)
            {
                if (regex.IsMatch(username) && username.Length < 26)
                {
                    usernames.Add(username);
                }
            }
            return usernames;
        }
    }
}