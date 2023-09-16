using App;

namespace Tests
{
    [TestClass]
    public class RomanNumberUnitTest
    {
        [TestMethod]
        public void TestParse()
        {
            Dictionary<String, int> test_cases = new()
            {
                {"I", 1},
                {"II", 2},
                {"III", 3},
                {"IIII", 4},
                {"IV", 4},
                {"IX", 9},
                {"LXII", 62},
                {"LXIII", 63},
                {"LXIV", 64},
                {"LXV", 65},
                {"LXVI", 66},
                {"LXVII", 67},
                {"LXXXI", 81},
                {"LXXXII", 82},
                {"LXXXIII", 83},
                {"LXXXIV", 84},
                {"LXXXV", 85},
                {"LXXXVI", 86},
                {"V", 5},
                {"VI", 6},
                {"VII", 7},
                {"VIII", 8},
                {"VIIII", 9},
                {"X", 10},
                {"XI", 11},
                {"XII", 12},
                {"XIII", 13},
                {"XIIII", 14},
                {"XIIIII", 15},
                {"XIV", 14},
                {"XL", 40},
                {"XLI", 41},
                {"XLII", 42},
                {"XLIII", 43},
                {"XLIV", 44},
                {"XLV", 45},
                {"XV", 15},
                {"XVI", 16},
                {"XVII", 17},
                {"XVIII", 18},
                {"XX", 20},
                {"XXIIIII", 25},
                {"XXV", 25},
                {"XXX", 30},
            };

            Assert.AreEqual(1, RomanNumber.Parse("I").Value, "1 == I");
            Assert.AreEqual(2, RomanNumber.Parse("II").Value, "2 == II");
            Assert.AreEqual(3, RomanNumber.Parse("III").Value, "3 == III");
            Assert.AreEqual(4, RomanNumber.Parse("IV").Value, "4 == IV");
            Assert.AreEqual(5, RomanNumber.Parse("V").Value, "5 == V");
            Assert.AreEqual(6, RomanNumber.Parse("VI").Value, "6 == VI");
            Assert.AreEqual(7, RomanNumber.Parse("VII").Value, "7 == VII");
            Assert.AreEqual(8, RomanNumber.Parse("VIII").Value, "8 == VIII");
            Assert.AreEqual(9, RomanNumber.Parse("IX").Value, "9 == IX");
            Assert.AreEqual(10, RomanNumber.Parse("X").Value, "10 == X");
            Assert.AreEqual(11, RomanNumber.Parse("XI").Value, "11 == XI");
            Assert.AreEqual(12, RomanNumber.Parse("XII").Value, "12 == XII");
            Assert.AreEqual(13, RomanNumber.Parse("XIII").Value, "13 == XIII");
            Assert.AreEqual(14, RomanNumber.Parse("XIV").Value, "14 == XIV");
            Assert.AreEqual(15, RomanNumber.Parse("XV").Value, "15 == XV");
            Assert.AreEqual(16, RomanNumber.Parse("XVI").Value, "16 == XVI");
            Assert.AreEqual(17, RomanNumber.Parse("XVII").Value, "17 == XVII");
            Assert.AreEqual(18, RomanNumber.Parse("XVIII").Value, "18 == XVIII");
            Assert.AreEqual(19, RomanNumber.Parse("XIX").Value, "19 == XIX");
            Assert.AreEqual(20, RomanNumber.Parse("XX").Value, "20 == XX");

            foreach (var pair in test_cases)
                Assert.AreEqual(pair.Value, RomanNumber.Parse(pair.Key).Value, $"{pair.Value} == {pair.Key}");
        }

        [TestMethod]
        public void TestException()
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(null!), "RomanNumber.Parse(null!) -> Exeption");

            var ex = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(""), "RomanNumber.Parse('') -> Exeption");

            Assert.IsFalse(String.IsNullOrEmpty(ex.Message), "ex.Message not empty");

            Dictionary<String, char> test_cases = new()
            {
                { "XA", 'A' },
                { "LB", 'B' },
                { "vI", 'v' },
                { "1X", '1' },
                { "$M", '$' },
                { "mX", 'm' },
                { "iM", 'i' }
            };

            foreach (var pair in test_cases)
                Assert.IsTrue(Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(pair.Key), $"RomanNumber.Parse({pair.Key}) -> Exeption").Message
                    .Contains($"'{pair.Value}'"), $"ex.Message contains '{pair.Value}'");

            string num = "MAM";
            ex = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(num));

            Assert.IsTrue(ex.Message.Contains("Invalid digit", StringComparison.OrdinalIgnoreCase), "ex.Message Contains 'Invalid digit'");
        }

        [TestMethod]
        public void TestParseInvalid()
        {
            Dictionary<String, char> test_cases = new Dictionary<string, char>()
            {
                { "X C", ' ' },
                { "X\tC", '\t' },
                { "X\nC", '\n' }
            };

            foreach (var pair in test_cases)
                Assert.IsTrue(Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(pair.Key), $"RomanNumber.Parse({pair.Key}) -> Exeption").Message
                    .Contains($"'{pair.Value}'"), $"ex.Message contains '{pair.Value}'");

            Dictionary<String, char[]> test_cases2 = new Dictionary<string, char[]>()
            {
                {"12XC", new[] { '1', '2' } },
                {"XC12", new[] { '1', '2' } },
                {"123XC", new[] { '1', '2', '3' } },
                {"321X", new[] { '3', '2', '1' } }
            };

            foreach (var pair in test_cases2)
            {
                var ex = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(pair.Key), $"Roman number parse {pair.Key} --> Exception");

                foreach (var c in pair.Value)
                    Assert.IsTrue(ex.Message.Contains($"{c}"), $"Roman number parse ({pair.Key}): ex.Message contains {c}");
            }
        }

        [TestMethod]
        public void TestParseDubious()
        {
            String[] dubious = { " XC", "XC ", "XC\n", "\tXC", " XC " };

            foreach (var str in dubious)
                Assert.IsNotNull(RomanNumber.Parse(str), $"Dubious '{str}' cause NULL");

            int value = 90;

            foreach (var pair in dubious)
                Assert.AreEqual(value, RomanNumber.Parse(pair).Value, $"Dobious equality {pair} --> {value}");

            String[] dubious2 = { "IIX", "VVX" };
            foreach (var str in dubious2)
                Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(str), $"Dubious '{str}' cause NULL");
        }

        [TestMethod]
        public void TestToString()
        {
            Dictionary<int, string> test_cases = new Dictionary<int, string>()
            {
                { 0, "N" },
                { 1, "I" },
                { 2, "II" },
                { 3, "III" },  
                { 4, "IV" },
                { 5, "V" },    
                { 6, "VI" },   
                { 7, "VII" },  
                { 8, "VIII" }, 
                { 9, "IX" },
                { 10, "X" },   
                { 11, "XI" },  
                { 12, "XII" }, 
                { 13, "XIII" },
                { 19, "XIX" },
                { 20, "XX" },  
                { 21, "XXI" }, 
                { 49, "XLIX" },
                { 50, "L" },   
                { 100, "C" },  
                { 399, "CCCXCIX" },
                { 400, "CD" },
                { 499, "CDXCIX" }, 
                { 500, "D" },   
                { 900, "CM" },  
                { 999, "CMXCIX" }, 
                { 1000, "M" },  
                { 3999, "MMMCMXCIX" }, 
                { -45, "-XLV" },
                { -95, "-XCV" },
                { -285, "-CCLXXXV" }
            };

            foreach (var item in test_cases)
                Assert.AreEqual(item.Value, new RomanNumber(item.Key).ToString(), $"{item.Key}.ToString() ---> '{item.Value}'");
        }

        [TestMethod]
        public void CrossTestParseToString()
        {
            List<int> test_values = new List<int>() { 1, 5, 10, 20, 50, 100, 500, 1000, 3999, -1, -5, -10, -20, -50, -100, -500, -1000, -3999 };

            foreach (var item in test_values)
            {
                RomanNumber r = new RomanNumber(item);
                string roman_str = r.ToString();

                Assert.AreEqual(item, RomanNumber.Parse(roman_str).Value, $"CrossTestParseToString (Message): {item} ---> {roman_str}");
            }
        }

        [TestMethod]
        public void  TypesFeatures()
        {
            RomanNumber r = new RomanNumber(10);

            Assert.AreEqual((short)10, r.Value);
        }

        [TestMethod]
        public void TestPlus()
        {
            RomanNumber r1 = new RomanNumber(10);
            RomanNumber r2 = new RomanNumber(20);
            var r3 = r1.Plus(r2);

            Assert.IsInstanceOfType(r1.Plus(r2), typeof(RomanNumber));
            Assert.AreNotSame(r1, r3);
            Assert.AreNotSame(r2, r3);
            Assert.AreEqual(30, r3.Value);
            Assert.AreEqual("XXX", r3.ToString());
            Assert.AreEqual(15, r1.Plus(new RomanNumber(5)).Value);
            Assert.AreEqual(1, r1.Plus(new RomanNumber(-9)).Value);
            Assert.AreEqual(-1, r1.Plus(new RomanNumber(-11)).Value);
            Assert.AreEqual(0, r1.Plus(new RomanNumber(-10)).Value);
            Assert.AreEqual(10, r1.Plus(new RomanNumber()).Value);
            Assert.AreEqual(5, RomanNumber.Parse("IV").Plus(new RomanNumber(1)).Value);
            Assert.AreEqual(-6, RomanNumber.Parse("-V").Plus(new RomanNumber(-1)).Value);
            Assert.AreEqual("N", new RomanNumber(20).Plus(new RomanNumber(-20)).ToString());
            Assert.AreEqual("-II", new RomanNumber(-20).Plus(new RomanNumber(18)).ToString());

            var ex = Assert.ThrowsException<ArgumentNullException>(() => r1.Plus(null!), "Plus(null!) -> ArgumentNullException");
            String expectedFragment = "Illegal Plus() invocation with null argument";

            Assert.IsTrue(ex.Message.Contains(expectedFragment, StringComparison.InvariantCultureIgnoreCase), 
                $"Plus(null!): ex.Message ({ex.Message}) contains '{expectedFragment}'");
        }

        [TestMethod]
        public void TestSum()
        {
            RomanNumber r1 = new RomanNumber(10);
            RomanNumber r2 = new RomanNumber(20);
            var r3 = RomanNumber.Sum(r1, r2);

            Assert.IsNotNull(r3);
            Assert.IsInstanceOfType(r3, typeof(RomanNumber));
            Assert.AreEqual(60, RomanNumber.Sum(r1, r2, r3).Value);
            Assert.AreEqual(0, RomanNumber.Sum().Value);

            var arr1 = Array.Empty<RomanNumber>();
            var arr2 = new RomanNumber[] { new RomanNumber(2), new RomanNumber(4), new RomanNumber(5) };

            Assert.IsNull(RomanNumber.Sum(null!, null!, null!), "NULL NULL NULL");
            Assert.AreEqual(0, RomanNumber.Sum(arr1).Value, "Empty arr -> Sum 0");
            Assert.AreEqual(11, RomanNumber.Sum(arr2).Value, "2-4-5 arr -> Sum 11");

            IEnumerable<RomanNumber> arr3 = new List<RomanNumber>() { new RomanNumber(2), new RomanNumber(4), new RomanNumber(5) };

            Assert.AreEqual(11, RomanNumber.Sum(arr3.ToArray()).Value, "2-4-5 list -> Sum11");

            Random rnd = new Random();

            for (int i = 0; i < 200; i += 1)
            {
                int x = rnd.Next(-3000, 3000);
                int y = rnd.Next(-3000, 3000);

                Assert.AreEqual(x + y, RomanNumber.Sum(new(x), new(y)).Value, $"{x} + {y} - rnd test");
            }

            for (int i = 0; i < 200; i += 1)
            {
                RomanNumber rx = new(rnd.Next(-3000, 3000));
                RomanNumber ry = new(rnd.Next(-3000, 3000));

                Assert.AreEqual(rx.Plus(ry).Value, RomanNumber.Sum(rx, ry).Value, $"{rx} + {ry} - rnd cross");
            }
        }
    }
}