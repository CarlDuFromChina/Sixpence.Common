using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sixpence.Common.Utils;
using System.Collections.Generic;

namespace Sixpence.Common.Test
{
    [TestClass]
    public class AssertTest
    {
        [TestMethod]
        public void Test()
        {
            Assert.ThrowsException<SpException>(() => AssertUtil.IsTrue(true, "�쳣����"), "�쳣����");
            Assert.ThrowsException<SpException>(() => AssertUtil.IsNullOrEmpty("", "�쳣����"), "�쳣����");
            Assert.ThrowsException<SpException>(() => AssertUtil.IsNull(null, "�쳣����"), "�쳣����");
            Assert.ThrowsException<SpException>(() => AssertUtil.IsEmpty(new List<string>(), "�쳣����"), "�쳣����");
        }
    }
}
