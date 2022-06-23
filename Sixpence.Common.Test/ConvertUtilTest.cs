using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sixpence.Common.Utils;

namespace Sixpence.Common.Test
{
	[TestClass]
	public class ConvertUtilTest
	{
		[TestMethod]
		public void Test()
		{
			Assert.IsTrue(ConvertUtil.ConToBoolean("true"));
			Assert.IsFalse(ConvertUtil.ConToBoolean("false"));
		}
	}
}

