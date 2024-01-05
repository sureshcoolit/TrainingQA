using NUnit.Framework;

namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method executed");
        }

        [Test]
        public void Test1()
        {
           TestContext.Progress.WriteLine("Executed Test 1 method");
           Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Executed Test 2 method");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Executed Teardown method");
        }
    }
}

