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
            Assert.ThrowsException<SpException>(() => AssertUtil.IsTrue(true, "“Ï≥£≤‚ ‘"), "“Ï≥£≤‚ ‘");
            Assert.ThrowsException<SpException>(() => AssertUtil.IsNullOrEmpty("", "“Ï≥£≤‚ ‘"), "“Ï≥£≤‚ ‘");
            Assert.ThrowsException<SpException>(() => AssertUtil.IsNull(null, "“Ï≥£≤‚ ‘"), "“Ï≥£≤‚ ‘");
            Assert.ThrowsException<SpException>(() => AssertUtil.IsEmpty(new List<string>(), "“Ï≥£≤‚ ‘"), "“Ï≥£≤‚ ‘");
        }
    }
}
