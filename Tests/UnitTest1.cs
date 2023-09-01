using APP;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRomanNumberParse()
        {
            Assert.AreEqual(1, RomanNumber.Parse("I").Value, "1 == I");
            Assert.AreEqual(2, RomanNumber.Parse("II").Value, "2 == II");
            Assert.AreEqual(5, RomanNumber.Parse("V").Value, "5 == V");
        }
    }
}