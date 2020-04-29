using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Elvi.XUnit.Framework.Core
{
    //https://github.com/kejn/TDD-xUnit/blob/master/xUnitMojeTesty/test/tests.py
    public abstract class TestCase
    {
        private readonly string _methodCall;

        protected TestCase(string methodCall)
        {
            _methodCall = methodCall;
        }

        public abstract void SetUp();

        public abstract void TearDown();

        public void Run(TestResult result)
        {
            result.TestStart();
            SetUp();
            try
            {
                MethodInfo methodInfo = this.GetType().GetMethod(_methodCall);
                if (methodInfo != null) 
                    methodInfo.Invoke(this, null);
                else
                    throw new NotImplementedException($"Method {_methodCall} doesn't exist in class {this.GetType().FullName}");
            }
            catch (Exception ex)
            {
                result.TestFail();
            }
            TearDown();
        }

    }
}
