using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tasks
{
    public class Task2
    {
        public static char? FirstNonRepeatingLetter(string str)
        {
            Dictionary<char, int> countChars = new Dictionary<char, int>();
            foreach (char symbol in str)
            {
                if (countChars.ContainsKey(char.ToLower(symbol)))
                {
                    countChars[char.ToLower(symbol)]++;
                }
                else if (countChars.ContainsKey(char.ToUpper(symbol)))
                {
                    countChars[char.ToUpper(symbol)]++;
                }
                else
                {
                    countChars.Add(symbol, 1);
                }
            }
            foreach (char symbol in str)
            {
                if (countChars[symbol] == 1)
                {
                    return symbol;
                }
            }
            return null;
        }
    }
}