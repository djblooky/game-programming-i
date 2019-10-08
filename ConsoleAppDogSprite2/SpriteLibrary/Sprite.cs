using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpriteLibrary
{
    public class Sprite
    {
        Point p = new Point();

        public Sprite()
        {
            p = new Point(100, 100);
        }

        public virtual string About()
        {
            return $"x:{this.p.X}, y:{this.p.Y}";
        }
    }
}
