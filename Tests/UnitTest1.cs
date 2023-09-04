using APP;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        // V - 0.2
        [TestMethod]
        public void TestRomanNumberParse()
        {
            Dictionary<String, int> test_cases = new()
            {
                { "II", 2 },
                { "III", 3 },
                { "IV", 4 },
                { "IIII", 4 }
            };

            Assert.AreEqual(1, RomanNumber.Parse("I").Value, "1 == I");

            foreach (var pair in test_cases)
                Assert.AreEqual(pair.Value, RomanNumber.Parse(pair.Key).Value, $"{pair.Value} == {pair.Key}");
        }

        // V - 0.1
        //[TestMethod]
        //public void TestRomanNumberParse()
        //{
        //    Assert.AreEqual(1, RomanNumber.Parse("I").Value, "1 == I");
        //    Assert.AreEqual(2, RomanNumber.Parse("II").Value, "2 == II");
        //    Assert.AreEqual(5, RomanNumber.Parse("V").Value, "5 == V");
        //}
    }
}