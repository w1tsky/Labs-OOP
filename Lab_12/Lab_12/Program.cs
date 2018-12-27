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
            Pasanger Boeing = new Pasanger();

            Reflector.ShowInfo(Boeing);

            Reflector.ShowInterface(Boeing);
            Reflector.ShowMethod(Boeing);

        }
    }
}
