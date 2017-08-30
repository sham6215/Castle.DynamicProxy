using Castle.DynamicProxy;
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
            Calculator c = generator.CreateClassProxy<Calculator>(new CalculatorInterceptor());
            c.Add(11, 22);
            c.Test();
            c.Devide(11, 22);
            Console.ReadKey();
        }
    }
}
