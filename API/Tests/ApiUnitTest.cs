using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.Tests
{
    [TestClass]
    public class ApiUnitTest
    {
        // runs first before every test
        [TestInitialize, TestCategory("Crowdtangle")]
        public void Setup()
        {
            Console.WriteLine("This is Setup");
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test Method One");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Test Method Two");
        }
        
        // runs last
        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine("This is Cleanup");
        }

        // test class methods need static
        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            Console.WriteLine("Class Setup");
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            Console.WriteLine("Class Cleanup");
        }

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext testContext)
        {
            Console.WriteLine("Assembly Setup");
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            Console.WriteLine("Assembly Cleanup");
        }
    }
}
