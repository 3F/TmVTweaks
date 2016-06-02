using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.r_eg.TmVTweaks.HotKeys;

namespace net.r_eg.TmVTweaksTest.HotKeys
{
    [TestClass]
    public class IdentHotKeyTest
    {
        [TestMethod]
        public void RangeTest1()
        {
            var uid = new IdentHotKey();
            Assert.AreEqual(IdentHotKey.MIN_VALUE, uid.Current);
            Assert.AreEqual(IdentHotKey.MIN_VALUE, uid.Current);
        }

        [TestMethod]
        //[ExpectedException(typeof(OverflowException))]
        public void RangeTest2()
        {
            var uid0 = new IdentHotKeyId(IdentHotKey.MAX_VALUE - 1);
            uid0.Next();

            try {
                var uid1 = new IdentHotKeyId(IdentHotKey.MAX_VALUE);
                uid1.Next();
                Assert.Fail("1");
            }
            catch(Exception ex) { Assert.IsTrue(ex.GetType() == typeof(OverflowException), ex.GetType().ToString()); }
        }

        [TestMethod]
        public void RangeTest3()
        {
            var uid = new IdentHotKey();
            int expected = IdentHotKey.MIN_VALUE;

            for(int i = 0; i < 12; ++i) {
                uid.Next();
                Assert.AreEqual(++expected, uid.Current);
                Assert.AreEqual(++expected, uid.Next().Current);
            }
        }

        [TestMethod]
        public void RangeTest4()
        {
            var uid = new IdentHotKey();

            Assert.AreEqual(0, uid.Iter.Count());
            uid.Next().Next().Next();
            Assert.AreEqual(3, uid.Iter.Count());
        }


        private class IdentHotKeyId: IdentHotKey
        {
            public IdentHotKeyId(int id)
            {
                this.id = id;
            }
        }
    }
}
