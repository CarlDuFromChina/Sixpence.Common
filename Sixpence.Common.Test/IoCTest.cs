using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sixpence.Common.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sixpence.Common.Test
{
    [TestClass]
    public class IoCTest
    {
        [TestInitialize]
        public void Initialize()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddServiceContainer();
        }

        [TestMethod]
        public void TestIocRegister()
        {
            Assert.IsNotNull(ServiceContainer.Resolve<ITest>());
            Assert.IsTrue(ServiceContainer.ResolveAll<ITest>().ToList().Count == 2);
            Assert.IsNotNull(ServiceContainer.Resolve<ITest>("BTest").GetTypeName() == "BTest");
            Assert.IsTrue(ServiceContainer.Resolve<ITest>(name => name == "ATest").GetTypeName() == "ATest");
            Assert.IsTrue(ServiceContainer.ResolveAll<ITest>(name => name.Contains("Test")).Count() == 2);
        }
    }

    [ServiceRegister]
    public interface ITest
    {
        string GetTypeName();
    }

    public class ATest : ITest
    {
        public string GetTypeName()
        {
            return this.GetType().Name;
        }
    }

    public class BTest : ITest
    {
        public string GetTypeName()
        {
            return this.GetType().Name;
        }
    }
}
