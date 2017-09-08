using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    abstract class BaseInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            OnStart(invocation);
            try
            {
                Proceed(invocation);
            }
            catch (Exception e)
            {
                OnException(invocation, e);
                throw;
            }
            finally
            {
                OnExit(invocation);
            }
        }

        protected virtual void Proceed(IInvocation invocation)
        {
            invocation.Proceed();
        }

        protected string[] GetTargetMethodCustomAttributes(IInvocation invocation)
        {
            var methods = invocation?.TargetType?.GetMethods();
            var info = methods?.FirstOrDefault(m => m?.Name == invocation?.Method?.Name);
            var attributes = info?.CustomAttributes?.Select(a => a?.AttributeType?.Name)?.ToArray();
            return attributes;
        }

        protected virtual void OnExit(IInvocation invocation) { }
        protected virtual void OnStart(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
    }
}
