using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HitCounter
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            HitCounter counter = new HitCounter();

            counter.Hit(1);
            counter.Hit(2);
            counter.Hit(3);

            Assert.AreEqual(3, counter.GetHits(4));

            counter.Hit(300);

            Assert.AreEqual(4, counter.GetHits(300));
            Assert.AreEqual(3, counter.GetHits(301));
        }

        [TestMethod]
        public void TestMethod2()
        {
            HitCounter counter = new HitCounter();

            counter.Hit(1);
            counter.Hit(2);
            counter.Hit(3);
            counter.Hit(3);
            counter.Hit(3);

            Assert.AreEqual(5, counter.GetHits(4));

            counter.Hit(300);

            Assert.AreEqual(6, counter.GetHits(300));
            Assert.AreEqual(5, counter.GetHits(301));
        }
    }
}
