using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;

namespace BreakoutGame
{

    enum BallState { OnPaddleStart, Playing }
    class Ball : DrawableSprite //add monogame library to references
    {
        public BallState State { get; private set; }
        GameConsole console;

        public Ball(Game1 game): base(game)
        {
            State = BallState.OnPaddleStart;
            console = (GameConsole)this.Game.Services.GetService<IGameConsole>();
            if(console == null)
            {
                console = new GameConsole(this.Game);
                this.Game.Components.Add(console);
            }

#if DEBUG
            this.ShowMarkers = true;
#endif
        }

        public void SetInitialLocation()
        {
            this.Location = new Vector2(200, 200);
        }

        public void LaunchBall(GameTime gameTime)
        {
            this.Speed = 190;

        }

        protected override void LoadContent()
        {
            this.spriteTexture = this.Game.Content.Load<Texture2D>("ballSmall"); //add images to content
            this.SetInitialLocation();
#if DEBUG
            this.console.GameConsoleWrite("Ball loaded...");
#endif
            base.LoadContent();
        }

    }

   
}
