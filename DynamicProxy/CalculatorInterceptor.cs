using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace DynamicProxy
{
    class CalculatorInterceptor : Interceptor
    {
        protected override void OnStart(IInvocation invocation)
        {
            Console.WriteLine("Start");
        }

        protected override void OnExit(IInvocation invocation)
        {
            Console.WriteLine("End");
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            Console.WriteLine("OnException: " + e.Message);
        }

        protected override bool NeedToSuppressException(IInvocation invocation, Exception e)
        {
            if (e.GetType() == typeof(NotImplementedException))
            {
                return true;
            }
            return false;
        }
    }
}
