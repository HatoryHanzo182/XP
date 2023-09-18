using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        private const char ZERO_DIGIT = 'N';
        private const String MINUS_SIGN = "-";
        private const String INVALID_DIGIT_MESSAGE = "Invalid digit";
        private const String INVALID_ROMAN_STRUCTURE_MESSAGE = "Invalid roman number structure";
        private const String EMPTY_OR_NULL_INPUT_MESSAGE = "Empty or NULL input";
        private const String INVALID_DIGIT_SEPARATOR = ", ";
        private const String DIGIT_FORMAT = "'{0}'";
        private const String PLUS_NULL_ARGUMENT_MESSAGE = "Illegal Plus() invocation with null argument";

        public int Value { get; set; }

        private static readonly Dictionary<char, int> roman_values = new Dictionary<char, int>
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
                _ => throw new ArgumentException($"{INVALID_DIGIT_MESSAGE} {string.Format(DIGIT_FORMAT, digit)}")
            };
        }

        private static void CheckValidityOrThrow(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException(EMPTY_OR_NULL_INPUT_MESSAGE);

            int firstDigitIndex = input.StartsWith(MINUS_SIGN) ? 1 : 0;

            List<char> invalidChars = new List<char>();
            for (int i = input.Length - 1; i >= firstDigitIndex; i--)
            {
                try { DigitValue(input[i]); }
                catch { invalidChars.Add(input[i]); }
            }

            if (invalidChars.Count > 0)
                throw new ArgumentException($"{input} Parse error: {INVALID_DIGIT_MESSAGE}: {string.Join(INVALID_DIGIT_SEPARATOR, 
                    invalidChars.Select(c => string.Format(DIGIT_FORMAT, c)))}");
        }

        private static void CheckCompositionOrThrow(string input)
        {
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
                        throw new ArgumentException(INVALID_ROMAN_STRUCTURE_MESSAGE);

                    flag = true;
                }
                else
                    flag = false;
            }
        }

        public static RomanNumber Parse(string input)
        {
            input = input?.Trim() ?? "";

            CheckValidityOrThrow(input);
            CheckCompositionOrThrow(input);

            int firstDigitIndex = input.StartsWith(MINUS_SIGN) ? 1 : 0;
            int result = 0;
            int prev = 0;

            for (int i = input.Length - 1; i >= firstDigitIndex; i--)
            {
                int current = DigitValue(input[i]);

                result += (current < prev) ? -current : current;
                prev = current;
            }

            return new RomanNumber { Value = firstDigitIndex == 0 ? result : -result };
        }

        public RomanNumber Plus(RomanNumber other)
        {
            if (other is null)
                throw new ArgumentNullException(PLUS_NULL_ARGUMENT_MESSAGE);

            return new RomanNumber(this.Value + other.Value);
        }

        public RomanNumber Minus(RomanNumber other)
        {
            if (other is null)
                throw new ArgumentNullException("Illegal Minus() invocation with null argument");

            int result = this.Value - other.Value;

            return new RomanNumber(result);
        }



        private static bool IsNull(RomanNumber n) => n == null;

        public static RomanNumber Sum(params RomanNumber[] numbers) 
        {
            if (numbers == null || (numbers.Length > 0 && numbers.All(IsNull)))
                return null!;

            var resRoman = new RomanNumber(0);

            foreach (var roman in numbers)
                resRoman.Value += roman.Value;

            return resRoman;
        }

        public override string ToString()
        {
            if (Value == 0)
                return ZERO_DIGIT.ToString();

            Dictionary<int, string> ranges = new Dictionary<int, string>
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
            long value = Math.Abs(Value);

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

        public static RomanNumber Eval(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be empty");

            input = input.Trim();

            string[] parts = input.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                throw new ArgumentException("Invalid input");

            string operand1 = parts[0].Trim();
            char operatorChar = input.FirstOrDefault(c => c == '+' || c == '-');
            string operand2 = parts[1].Trim();

            bool isOperand1Negative = operand1.StartsWith("-");
            bool isOperand2Negative = operand2.StartsWith("-");

            operand1 = isOperand1Negative ? operand1.Substring(1) : operand1;
            operand2 = isOperand2Negative ? operand2.Substring(1) : operand2;

            if (string.IsNullOrEmpty(operand1) || string.IsNullOrEmpty(operand2) || operatorChar == '\0')
                throw new ArgumentException("Invalid input");

            RomanNumber romanOperand1 = RomanNumber.Parse(operand1);
            RomanNumber romanOperand2 = RomanNumber.Parse(operand2);

            if (isOperand1Negative)
                romanOperand1 = romanOperand1.Minus(romanOperand1).Negate();
            if (isOperand2Negative)
                romanOperand2 = romanOperand2.Minus(romanOperand2).Negate();
            if (operatorChar == '+')
                return romanOperand1.Plus(romanOperand2);
            else if (operatorChar == '-')
                return romanOperand1.Minus(romanOperand2);
            else
                throw new ArgumentException($"Invalid operator. Only + and - are allowed. Expression: {input}");
        }

        public RomanNumber Negate() { return new RomanNumber(-Value); }
    }
}