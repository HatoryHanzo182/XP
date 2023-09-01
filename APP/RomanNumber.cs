using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP
{
    public class RomanNumber
    {
        private static Dictionary<int, string> _roman_numerals;  // Contains Roman and Arabic numerals.

        public Int32 Value { get; set; }

        static RomanNumber()
        {
            _roman_numerals = new Dictionary<int, string>()
            {
                {1, "I"},
                {2, "II"},
                {5, "V"}
            };
        }

        public static RomanNumber Parse(string input)  // Converting a Roman notation for a number (represented as a string) to an
        {                                             // integer (Int32) and returning that integer as an object of type RomanNumber.
            int result = 0;  // Contain the result of converting a Roman numeral to an integer.

            for (int i = 0; i < input.Length; i++)
            {
                 // This part of the code checks if the current character is less than the next character in Roman notation.
                // This checks for cases where a Roman numeral is written in a form where the smaller digit comes before the larger one.
                string current_symbol = input[i].ToString();

                if (i < input.Length - 1 && _roman_numerals.ContainsValue(current_symbol) && _roman_numerals.ContainsValue(input[i + 1].ToString()) 
                    && _roman_numerals.FirstOrDefault(x => x.Value == current_symbol).Key < _roman_numerals.FirstOrDefault(x => x.Value == input[i + 1].ToString()).Key)
                    result -= _roman_numerals.FirstOrDefault(x => x.Value == current_symbol).Key;
                else
                    result += _roman_numerals.FirstOrDefault(x => x.Value == current_symbol).Key;
            }

            return new RomanNumber { Value = result };
        }
    }
}
