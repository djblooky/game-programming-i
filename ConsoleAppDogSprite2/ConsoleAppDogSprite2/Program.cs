using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDogSprite2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();
            Console.WriteLine(d.About());
            Console.ReadKey();
        }
    }
}
