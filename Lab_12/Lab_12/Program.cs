using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Aviation aviation = new Aviation();
            Reflector.OutInfoInToFile(aviation);
            Console.WriteLine('\n');
            Reflector.AllPublicMethod(aviation);
            Console.WriteLine('\n');
            Reflector.InfoFieldsAndProperties(aviation);
            Console.WriteLine('\n');
            Reflector.AllInterface(aviation);
            Console.WriteLine('\n');
            Reflector.ParametrMethof(aviation);
            Console.WriteLine('\n');
            Reflector.MethodCall(aviation, "Method");
            Console.ReadKey();
        }
    }
}
