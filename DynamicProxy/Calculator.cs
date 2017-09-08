using DynamicProxy.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    public class Calculator
    {
        public virtual string TestProp => "Test property";

        [Catchable]
        public virtual int Add(int a, int b)
        {
            Console.WriteLine($"Calculator: Add: {a} + {b}");
            throw new NotImplementedException("test Add");
            return a + b;
        }

        public virtual int Devide(int a, int b)
        {
            Console.WriteLine($"Calculator: Devide: {a} + {b}");
            throw new Exception("test Devide");
            return a - b;
        }

        [Catchable]
        public virtual void Test()
        {
            Console.WriteLine($"Calculator: Test");
            throw new NotImplementedException("test Test");
        }
    }
}
