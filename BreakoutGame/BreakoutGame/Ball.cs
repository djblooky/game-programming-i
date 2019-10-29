using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakoutGame
{
    class Ball : DrawableSprite //add monogame library to references
    {
        public Ball(Game1 game): base(game)
        {

        }

#if DEBUG
        this.ShowMarkers = true;
#endif
    }

    public void setInitialLocation()
    {
        this.Location = new Vector2(200, 200);
    }

    protected override void LoadContent()
    {
        this.spriteTexture = this.Game.Content.Load<Texture2D>("ballSmall"); //add images to content
        this.setInitialLocation();
        base.LoadContent();
    }
}
