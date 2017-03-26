using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Logic;

namespace Task3Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Polynomial(1, 2, 3, 4, 5);
            var b = new Polynomial(1, 2, 3, 4, 5);
            //Console.WriteLine(a * 2);
            Console.WriteLine(a);
            Console.WriteLine(b);
            var c = a + b;
            Console.WriteLine(a * b);
            
        }
    }
}
