using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FPS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Sprite> sprites;
        FPSComponent fps;

        public Game1()
        {
            sprites = new List<Sprite>();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            fps = new FPSComponent(this, false, false); //set last two to false, test speed of card plugged vs unplugged
            this.Components.Add(fps);
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            CreateSprites(100);

            base.Initialize();
        }

        void CreateSprites(int numOfSprites)
        {
            for(int i=0; i<numOfSprites; i++)
            {
                sprites.Add(new Sprite());
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadSprites();
            
        }

        void LoadSprites()
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.texture = Content.Load<Texture2D>("kirby");
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            UpdateSpritesMovement(gameTime);

            base.Update(gameTime);
        }

        void UpdateSpritesMovement(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds; //elapsed time
            foreach (Sprite sprite in sprites)
            {
                sprite.location = sprite.location + ((sprite.direction * sprite.speed) * (time / 1000)); //time corrected move
            }
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawSprites();
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        void DrawSprites()
        {
            foreach (Sprite sprite in sprites)
            {
                spriteBatch.Draw(sprite.texture, sprite.location, Color.White);
            }
        }
    }
}
