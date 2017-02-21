using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Match_Phone_Number
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"(\+\d{3}\s\d\s\d{3}\s\d{4})\b|(\+\d{3}-\d-\d{3}-\d{4})\b");
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
