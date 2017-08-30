using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    public class Calculator
    {
        public virtual int Add(int a, int b)
        {
            throw new NotImplementedException("test Add");
            return a + b;
        }

        public virtual int Devide(int a, int b)
        {
            throw new Exception("test Devide");
            return a - b;
        }

        public virtual void Test()
        {
            throw new NotImplementedException("test Test");
        }
    }
}
