using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    abstract class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            OnStart(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                OnException(invocation, e);
                if (!NeedToSuppressException(invocation, e))
                    throw;
                SetDefaultReturnValue(invocation);
            }
            finally
            {
                OnExit(invocation);
            }
        }

        private void SetDefaultReturnValue(IInvocation invocation)
        {
            Type t = invocation.Method.ReturnType;

            if (t == typeof(void))
                return;

            if (IsNullableType(t))
            {
                invocation.ReturnValue = null;
            } else
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

        protected abstract void OnExit(IInvocation invocation);
        protected abstract void OnStart(IInvocation invocation);
        protected abstract void OnException(IInvocation invocation, Exception e);
        protected abstract bool NeedToSuppressException(IInvocation invocation, Exception e);
    }
}
