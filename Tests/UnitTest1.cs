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
        }
    }
}