using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Extract_emails
{
    public class ExtractEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"([\w-.]+@[a-zA-Z-]+)(\.[a-zA-Z-]+)+";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var result = match.ToString();
                if (!(result.StartsWith("-") || result.StartsWith(".") || result.StartsWith("_")
                    || result.EndsWith("-") || result.EndsWith(".") || result.EndsWith("_")))
                    Console.WriteLine(result);
            }
        }
    }
}
