using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vigor.Utils.Inputs;
using Vigor.Entity;
using System;

namespace Vigor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D test;
        int _width;
        int _height;
        float gamePadX;
        float gamePadY;
        Player player;

        SpriteFont spriteFont;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);

            //Fullscreen
            //_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.PreferredBackBufferWidth = _width;
            //graphics.PreferredBackBufferHeight = _height;
            //graphics.ApplyChanges();

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
            player = new Player(this.Content.Load<Texture2D>("link"), new Vector2(), 5);
            //this.test = this.Content.Load<Texture2D>("default");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

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
            gamePadX = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            gamePadY = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;

            InputController.HandlePlayerInput(gamePadX, gamePadY, player);
            player.Update(gameTime);

            //Console.WriteLine(gameTime.TotalGameTime);

            base.Update(gameTime);
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
            player.Draw(spriteBatch);
            spriteBatch.DrawString(spriteFont, string.Format("gamepad-X{0} : gamepad-Y{1}", gamePadX, gamePadY), new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight - 30), Color.Black);
            spriteBatch.End();


            base.Draw(gameTime);
        }

        
    }
}
