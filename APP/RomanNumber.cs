using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        private const char ZERO_DIGIT = 'N';
        private const String MINUS_SIGN = "-";
        private const String INVALID_DIGIT_MESSAGE = "Invalid digit";
        public int Value { get; set; }
        private static Dictionary<char, int> roman_values = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public RomanNumber(int value = 0) 
        {
            Value = value;
        }

        private static int DigitValue(char digit)
        {
            return digit switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                ZERO_DIGIT => 0,
                _ => throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} '{digit}'")
            };
        }

        private static void CeckValidityOrTrow(string input)
        {
            #region Number check.
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Empty or NULL input");

            int firstDigitIndex = input.StartsWith(MINUS_SIGN) ? 1 : 0;

            List<char> invalidChars = new List<char>();
            for (int i = input.Length - 1; i >= firstDigitIndex; i--)
            {
                try { DigitValue(input[i]); }
                catch { invalidChars.Add(input[i]); }
            }

            if (invalidChars.Count > 0)
                throw new ArgumentException($"'{input}' Parse error: Invalid digits: '{String.Join(", ", invalidChars.Select(c => $"'{c}'"))}'");
            #endregion
        }

        private static void CheckCompositionOrTrow(string input)
        {
            #region Correct number composition.
            int maxDigit = 0;
            bool flag = false;
            int firstDigitIndex = input.StartsWith(MINUS_SIGN) ? 1 : 0;

            for (int i = input.Length - 1; i >= firstDigitIndex; i--)
            {
                int current = DigitValue(input[i]);

                if (current > maxDigit)
                    maxDigit = current;
                if (current < maxDigit)
                {
                    if (flag)
                        throw new ArgumentException("Invalid roman number structure");

                    flag = true;
                }
                else
                    flag = false;
            }
            #endregion
        }

        public static RomanNumber Parse(String input)
        {
            input = input?.Trim()!;

            CeckValidityOrTrow(input);
            CheckCompositionOrTrow(input);

            int firstDigitIndex = input.StartsWith(MINUS_SIGN) ? 1 : 0;
            int result = 0;
            int prev = 0;  

            for (int i = input.Length - 1; i >= firstDigitIndex; i--)
            {
                int current = DigitValue(input[i]);

                result += (current < prev) ? -current : current;
                prev = current;
            }
            
            return new RomanNumber() { Value = firstDigitIndex == 0 ? result : -result };
        }

        public override string ToString() 
        {
            if (Value == 0)
                return ZERO_DIGIT.ToString();

            Dictionary<int, string> ranges = new Dictionary<int, string>() 
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };

            StringBuilder result = new StringBuilder();
            int value = Math.Abs(Value);

            foreach (var range in ranges)
            {
                while (value >= range.Key)
                {
                    result.Append(range.Value);
                    value -= range.Key;
                }
            }

            return Value < 0 ? $"{MINUS_SIGN}{result}" : result.ToString();
        }
    }
}