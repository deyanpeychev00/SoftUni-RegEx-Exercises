using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Extract_sentences_by_keyword
{
    public class ExtractSentencesByKeyword
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            var splitSymbols = new char[] { '.', '!', '?' };
            var input = Console.ReadLine().Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
            var keyword = "\\b" + key + "\\b";
            var regex = new Regex(keyword);

            foreach (var sentence in input)
            {
                if (regex.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
