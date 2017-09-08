using Castle.DynamicProxy;
using DynamicProxy.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();
            IInterceptor[] interceptors = new IInterceptor[] {
                new ExceptionInterceptor(),
                new LoggingInterceptor()
            };

            Calculator c = generator.CreateClassProxy<Calculator>(interceptors);

            try
            {
                string s = c.TestProp;
                Console.WriteLine("");
                c.Add(11, 22);
                Console.WriteLine("");
                c.Test();
                Console.WriteLine("");
                c.Devide(11, 22);
            } catch (Exception) { }
            Console.ReadKey();
        }
    }
}
