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

        public static RomanNumber Parse(String input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Empty or NULL input");

            int result = 0;
            int prev = 0;
            int first_digit_index = input.StartsWith("-") ? 1 : 0;

            for (int i = input.Length - 1; i >= first_digit_index; i--)
            {
                int current = input[i] switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                    'N' => 0,
                    _ => throw new ArgumentException(" 'A'B' ")
                };

                result += (current < prev) ? -current : current;
                prev = current;
            }
            return new RomanNumber() { Value = result * (1 - (first_digit_index << 1)) };
        }
    }
}