/*
 * Morgan Walker
 * Where the game gets intialized
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Blueboi.Scenes;

namespace Blueboi
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        //declare all scnes here
        private StartScene startScene;
        //actionscene
        private ActionScene actionScene;
        //helpscene
        private HelpScene helpScene;

        private CreditScene creditScene;

        private EndScene endScene;

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
            // Get screen width and height
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
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

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.Hide(false);
            startScene.PlayMusic();

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);
            actionScene.Hide(true);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);
            helpScene.Hide(true);

            creditScene = new CreditScene(this);
            this.Components.Add(creditScene);
            creditScene.Hide(true);

            endScene = new EndScene(this);
            this.Components.Add(endScene);
            endScene.Hide(true);
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
            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    actionScene.Hide(false);
                    startScene.Hide(true);
                    actionScene.PlayMusic();
                }
                if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    helpScene.Hide(false);
                    startScene.Hide(true);
                    helpScene.PlayMusic();
                }
                if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    creditScene.Hide(false);
                    startScene.Hide(true);
                    creditScene.PlayMusic();
                }
                if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.Hide(false);
                    actionScene.Hide(true);
                    startScene.PlayMusic();
                }

            }
            if (actionScene.Enabled && Shared.playerHealth == 0)
            {
                actionScene.Hide(true);
                endScene.Hide(false);
                endScene.PlayMusic();
            }

            if (endScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
            }
            if (helpScene.Enabled)
            {

                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.Hide(false);
                    helpScene.Hide(true);
                    startScene.PlayMusic();
                }

            }

            if (creditScene.Enabled)
            {

                if (ks.IsKeyDown(Keys.Escape))
                {
                    startScene.Hide(false);
                    creditScene.Hide(true);
                    startScene.PlayMusic();
                }

            }
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
