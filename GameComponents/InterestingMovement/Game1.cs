using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InterestingMovement
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        Texture2D kirby;
        Vector2 kirbyLoc;
        Vector2 kirbyDir;
        float kirbySpeed, kirbyMaxSpeed, kirbyAcceleration;

        enum kirbyMovementState {Reverse, SpeedToggle, DirectionToggle}
        kirbyMovementState currentMovementState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("font");

            kirby = Content.Load<Texture2D>("kirby");
            kirbyLoc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            kirbyDir = new Vector2(1, 0);

            kirbySpeed = 50;
            kirbyMaxSpeed = 100;
            kirbyAcceleration = 3;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds; //elapsed time
            kirbyLoc = kirbyLoc + ((kirbyDir * kirbySpeed) * (time / 1000)); //time corrected move

            updateKeepKirbyOnScreen();
            updatekirbyBasedOnState();

            updateKeyInput();

            base.Update(gameTime);
        }

        private void updatekirbyBasedOnState()
        {
            //Movement for next frame
            //Handle movement modes
            switch (currentMovementState)
            {
              
                case kirbyMovementState.SpeedToggle:
                    kirbySpeed = 0;

                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        kirbySpeed += 1;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        kirbySpeed -= 1;
                    }

                    break;
               
                case kirbyMovementState.DirectionToggle:
                    if (Keyboard.GetState().GetPressedKeys().Length > 0) //If there is any key press the legth of the Array of keys returned by GetPressedKeys wil be greater that 0
                    {
                        kirbySpeed = 0;
                    }
                    else if (Keyboard.GetState().GetPressedKeys().Length > 1)
                    {
                        kirbySpeed = 100;
                    }
                    else
                    {
                        kirbySpeed = 50;
                    }
                    break;
                
                case kirbyMovementState.Reverse:
                    
                    if (Keyboard.GetState().GetPressedKeys().Length == 0) //If there is any key press the legth of the Array of keys returned by GetPressedKeys wil be greater that 0
                    {
                        if (kirbySpeed > 0)
                        {
                            kirbySpeed += kirbyAcceleration;
                        }
                    }
                    else
                    {
                        if (kirbySpeed < kirbyMaxSpeed)
                        {
                            kirbySpeed -= kirbyAcceleration;
                        }
                    }
                    break;
          
            }

                //normalize vector
                if (kirbyDir.Length() >= 1.0)
                {
                    kirbyDir.Normalize();
                }
          
        }

        private void updateKeepKirbyOnScreen()
        {
            //Turn kirby Around if it hits the edge of the screen
            if ((kirbyLoc.X > GraphicsDevice.Viewport.Width - kirby.Width)
                || (kirbyLoc.X < 0))
            {
                kirbyDir *= new Vector2(-1, 0);
            }
            if ((kirbyLoc.Y > GraphicsDevice.Viewport.Height - kirby.Height)
                || (kirbyLoc.Y < 0))
            {
                kirbyDir *= new Vector2(0, -1);
            }
        }

        private void updateKeyInput()
        {
            #region Keyboard Movement
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                kirbyDir += new Vector2(0, 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                kirbyDir += new Vector2(0, -1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                kirbyDir += new Vector2(1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                kirbyDir += new Vector2(-1, 0);
            }
            #endregion

            #region Keyboard MovementModes
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                currentMovementState = kirbyMovementState.SpeedToggle;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                currentMovementState = kirbyMovementState.DirectionToggle;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                currentMovementState = kirbyMovementState.Reverse;
            }
            #endregion
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "CurrentMode:" + currentMovementState, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, "S:SpeedToggle D:DirectionToggle R:Reverse", new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, "kirbySpeed:" + kirbySpeed + " kirbyMaxSpeed:" + kirbyMaxSpeed, new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(font, "kirbyDir:" + kirbyDir + " Length()" + kirbyDir.Length(), new Vector2(10, 70), Color.White);
            spriteBatch.DrawString(font, "kirbyAcceleration:" + kirbyAcceleration, new Vector2(10, 90), Color.White);
            spriteBatch.DrawString(font, "kirbyLoc:" + kirbyLoc, new Vector2(10, 110), Color.White);

            spriteBatch.Draw(kirby, kirbyLoc, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
