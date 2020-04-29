using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Elvi.XUnit.Framework.Core
{
    public class TestSuite
    {
        private readonly List<TestCase> _testsCases;
        public TestSuite()
        {
            _testsCases = new List<TestCase>();
        }

        public void Add(TestCase testCaller)
        {
            _testsCases.Add(testCaller);
        }

        public void Run(TestResult result)
        {
            foreach (TestCase testCase in _testsCases)
            {
                testCase.Run(result);
            }
        }
    }
}
