using App;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRomanNumberParse()
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
        public void TestRomanNumberParseInvalid()
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(null!), "RomanNumber.Parse(null!) -> Exeption");

            var ex = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(""), "RomanNumber.Parse('') -> Exeption");

            Assert.IsFalse(String.IsNullOrEmpty(ex.Message), "ex.Message not empty");

            Dictionary<String, char> test_cases = new()
            {
                { "XA", 'A'},
                { "LB", 'B'}
            };

            foreach (var pair in test_cases)
                Assert.IsTrue(Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(pair.Key), $"RomanNumber.Parse({pair.Key}) -> Exeption").Message
                    .Contains($"'{pair.Value}'"), $"ex.Message contains '{pair.Value}'");
        }
    }
}