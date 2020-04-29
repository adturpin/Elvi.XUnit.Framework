using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elvi.XUnit.Framework.Core;

namespace Elvi.XUnit.Framework.Runner
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                
                TestSuite testSuite = new TestSuite();
                testSuite.Add(new TestCaseTest("TestTemplateMethod"));
                testSuite.Add(new TestCaseTest("TestResult"));
                testSuite.Add(new TestCaseTest("TestFailedResult"));
                testSuite.Add(new TestCaseTest("TestFailedResultFormatting"));
                testSuite.Add(new TestCaseTest("Test_Suite"));
                TestResult result = new TestResult();
                testSuite.Run(result);
                
                Console.WriteLine("result :" + result.Summary());
            }
            catch (Exception ex)
            {
                Console.WriteLine("---Error--- : "+ex );
            }

            Console.ReadKey();
        }
    }

    public class WasRun : TestCase
    {
        public string log;
        public WasRun(string methodCall)
            : base(methodCall)
        {

        }

        public override void SetUp()
        {
            log += "SetUp ";
        }

        public override void TearDown()
        {
            log += "TearDown ";
        }

        public void TestMethod()
        {
            log += "TestMethod ";
        }

        public void TestBrokenMethod()
        {
            throw new Exception("Broken");
        }
    }

    public class TestCaseTest : TestCase
    {
        private TestResult result;
        public TestCaseTest(string methodCall) 
            : base(methodCall)
        {
        }

        public override void SetUp()
        {
            result = new TestResult();
        }

        public override void TearDown()
        {
        }

        public void TestTemplateMethod()
        {
            TestCase test = new WasRun("TestMethod");
            test.Run(result);
            Console.WriteLine("setUp testMethod tearDown =>" + ((WasRun)test).log);
        }
        public void TestResult()
        {
            TestCase test = new WasRun("TestMethod");
            test.Run(result);
            Console.WriteLine("1 run, 0 failed =>" + result.Summary());

        }
        public void TestFailedResult()
        {
            TestCase test = new WasRun("TestBrokenMethod");
            test.Run(result);
            Console.WriteLine("1 run, 1 failed =>" + result.Summary());
        }
        public void TestFailedResultFormatting()
        {
            result.TestStart();
            result.TestFail();
            Console.WriteLine("1 run, 1 failed  =>" + result.Summary());
        }
        public void Test_Suite()
        {
            TestSuite testSuite = new TestSuite();
            testSuite.Add(new WasRun("TestMethod"));
            testSuite.Add(new WasRun("TestBrokenMethod"));
            testSuite.Run(result);
            Console.WriteLine("2 run, 1 failed =>" + result.Summary());
        }

    }
}
