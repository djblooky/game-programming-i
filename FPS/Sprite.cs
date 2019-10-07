using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FPS
{
    public class Sprite
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }

        public Vector2 direction;
        public float speed, maxSpeed, acceleration;

        public Sprite()
        {
            location = new Vector2(1, 1);
            direction = new Vector2(-1, 0);
            speed = 20;
            maxSpeed = 100;
            acceleration = 2;
        }

    }
}
