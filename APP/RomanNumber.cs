using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
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

        public static RomanNumber Parse(String input)
        {
            input = input?.Trim()!;

            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Empty or NULL input");

            int result = 0;
            int prev = 0;  
            int firstDigitIndex = input.StartsWith("-") ? 1 : 0;
            List<char> invalidChars = new();
            int maxDigit = 0;
            bool flag = false;

            for (int i = input.Length - 1; i >= firstDigitIndex; i--)
            {
                int current = maxDigit;

                try
                {
                    current = input[i] switch
                    {
                        'I' => 1,
                        'V' => 5,
                        'X' => 10,
                        'L' => 50,
                        'C' => 100,
                        'D' => 500,
                        'M' => 1000,
                        'N' => 0,
                        _ => throw new ArgumentException($"'{input}' Parse error: Invalid digit '{input[i]}' ")
                    };
                }
                catch { invalidChars.Add(input[i]); }

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

                result += (current < prev) ? -current : current;
                prev = current;
            }
            if (invalidChars.Count > 0)
                throw new ArgumentException($"'{input}' Parse error: Invalid digits: '{String.Join(", ", invalidChars.Select(c => $"'{c}'"))}' ");
            
            return new RomanNumber() { Value = firstDigitIndex == 0 ? result : -result };
        }

        public override string ToString() 
        {
            if (Value == 0)
                return "N";

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

            return Value < 0 ? $"-{result}" : result.ToString();
        }
    }
}