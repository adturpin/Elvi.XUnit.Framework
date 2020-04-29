using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvi.XUnit.Framework.Core
{
    public class TestResult
    {
        private int _runCount;
        private int _errorCount;

        public TestResult()
        {
            _errorCount = 0;
            _runCount = 0;
        }

        public void TestStart()
        {
            _runCount++;
        }

        public void TestFail()
        {
            _errorCount++;
        }

        public string Summary()
        {
            return $"{_runCount} run , {_errorCount} failed";
        }
    }
}
