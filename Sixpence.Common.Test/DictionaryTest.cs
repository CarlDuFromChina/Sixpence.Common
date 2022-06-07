using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sixpence.Common.Test
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void TestToDictionary()
        {
            var obj = new
            {
                name = "Eric",
                age = 12
            };
            var dic = obj.ToDictionary();

            Assert.IsNotNull(dic);
            dic.TryGetValue("age", out var age);
            Assert.IsTrue(dic.Count > 0 && dic["name"].ToString() == "Eric" && Convert.ToInt32(age) == 12);
        }
    }
}
