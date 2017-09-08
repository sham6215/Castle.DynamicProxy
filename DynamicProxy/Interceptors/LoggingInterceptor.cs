using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy.Interceptors
{
    class LoggingInterceptor : BaseInterceptor
    {
        protected override void Proceed(IInvocation invocation)
        {
            Console.WriteLine("Proceed: LoggingInterceptor");
            invocation.Proceed();
        }

        protected override void OnStart(IInvocation invocation)
        {
            Console.WriteLine("Start : LoggingInterceptor");
        }

        protected override void OnExit(IInvocation invocation)
        {
            Console.WriteLine("End : LoggingInterceptor");
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            Console.WriteLine("OnException : LoggingInterceptor : " + e.Message);
        }
    }
}
