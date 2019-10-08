using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteLibrary;

namespace ConsoleAppDogSprite2
{
    class Dog : Sprite
    {
        public string name;

        public Dog()
        {
            this.name = "boof";
        }

        public override string About()
        {
            return base.About() + $"\tname{this.name}";
        }
    }
}
