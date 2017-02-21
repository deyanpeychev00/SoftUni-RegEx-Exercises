using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.Match_Full_Name
{
    public class MatchFullName
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

        }
    }
}
