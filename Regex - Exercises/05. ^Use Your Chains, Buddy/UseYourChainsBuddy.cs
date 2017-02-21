using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.__Use_Your_Chains__Buddy
{
    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            var input = Console.ReadLine();
         // var input = File.ReadAllText(@"input.txt");
            var pattern = @"<p>(\s+\w.*?|\w.*?)<\/p>";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            var matchList = matches.Cast<Match>().Select(match => match.Groups[1].ToString()).ToList();
            var tags = ConvertMatchesToList(matchList);
            var tagsCopy = CopyList(tags);
            var result = DecryptTags(tagsCopy);
            var resultString = "";
            foreach (var letter in result)
            {
                resultString += letter;
            }
            var final = resultString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
           
            Console.WriteLine(string.Join(" ", final));
        }

        private static List<string> CopyList(List<string> tags)
        {
            var tagsCopy = new List<string>();
            foreach (var tag in tags)
            {
                tagsCopy.Add(tag);
            }
            return tagsCopy;
        }
        private static List<string> DecryptTags(List<string> tagsCopy)
        {
            var fromAtoM = new Dictionary<char, char>(){
                {'a','n'},
                {'b', 'o'},
                {'c', 'p'},
                {'d', 'q'},
                {'e', 'r'},
                {'f', 's'},
                {'g', 't'},
                {'h', 'u'},
                {'i', 'v'},
                {'j','w'},
                {'k','x'},
                {'l','y'},
                {'m', 'z'}
            };
            var fromNtoZ = new Dictionary<char, char>(){
                {'n','a'},
                {'o', 'b'},
                {'p', 'c'},
                {'q', 'd'},
                {'r', 'e'},
                {'s', 'f'},
                {'t', 'g'},
                {'u', 'h'},
                {'v', 'i'},
                {'w','j'},
                {'x','k'},
                {'y','l'},
                {'z', 'm'}
            };
            var numbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var result = new List<string>();

            var isSpace = false;
            foreach (var tag in tagsCopy)
            {
                foreach (var letter in tag)
                {
                   
                    var letterToDecrypt = letter;
                    if (fromAtoM.ContainsKey(letterToDecrypt))
                    {
                        letterToDecrypt = fromAtoM[letterToDecrypt];
                        isSpace = false;
                    }
                    else if (fromNtoZ.ContainsKey(letterToDecrypt))
                    {
                        letterToDecrypt = fromNtoZ[letterToDecrypt];
                        isSpace = false;
                    }
                    else if (letterToDecrypt != ' ' && !numbers.Contains(letterToDecrypt) && isSpace == false)
                    {
                        letterToDecrypt = ' ';
                        isSpace = true;
                    }
                    if ((letterToDecrypt >= 'a' && letterToDecrypt <= 'z')
                        || (letterToDecrypt >= '0' && letterToDecrypt <= '9')
                        || letterToDecrypt == ' ')
                    {
                        result.Add(letterToDecrypt.ToString());
                    }

                }

            }
            return result;
        }      
        private static List<string> ConvertMatchesToList(List<string> matchList)
        {
            var tags = new List<string>();
            foreach (var item in matchList)
            {
                tags.Add(item.ToString());
            }
            return tags;
        }
    }
}