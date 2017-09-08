using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using DynamicProxy.Attributes;

namespace DynamicProxy.Interceptors
{
    class ExceptionInterceptor : BaseInterceptor
    {
        private string AttributeCatchable => "CatchableAttribute";

        protected override void OnStart(IInvocation invocation)
        {
            Console.WriteLine("Start: ExceptionInterceptor");
        }

        protected override void OnExit(IInvocation invocation)
        {
            Console.WriteLine("End: ExceptionInterceptor");
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            Console.WriteLine("OnException: ExceptionInterceptor: " + e.Message);
        }

        protected override void Proceed(IInvocation invocation)
        {
            Console.WriteLine("Proceed: ExceptionInterceptor");
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                if (!NeedToSuppressException(invocation, e))
                    throw;
                Console.WriteLine("ExceptionInterceptor: Proceed exception is suppressed");
                SetDefaultReturnValue(invocation);
            }
        }

        private bool NeedToSuppressException(IInvocation invocation, Exception e)
        {
            var attributes = GetTargetMethodCustomAttributes(invocation);
            var attribute = attributes?.FirstOrDefault(attrName => attrName == AttributeCatchable);
            return string.IsNullOrEmpty(attribute) ? false : true;
        }

        private void SetDefaultReturnValue(IInvocation invocation)
        {
            Type t = invocation.Method.ReturnType;

            if (t == typeof(void))
                return;

            if (IsNullableType(t))
            {
                invocation.ReturnValue = null;
            }
            else
            {
                invocation.ReturnValue = Activator.CreateInstance(t);
            }
        }

        private bool IsNullableType(Type t)
        {
            if (!t.IsValueType)
                return true;
            if (Nullable.GetUnderlyingType(t) != null)
                return true;
            return false;
        }
    }
}
