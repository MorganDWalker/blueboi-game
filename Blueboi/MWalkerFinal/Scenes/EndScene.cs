/*
 * Morgan Walker
 * The scene that will display when the player loses
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Blueboi.Scenes
{
    class EndScene : Scene
    {
        // Class level variables
        private SpriteBatch spriteBatch;
        private Texture2D endScreen;
        private SpriteFont font;

        /// <summary>
        /// Constructor for the EndScene
        /// </summary>
        /// <param name="game"></param>
        public EndScene(Game game) : base(game)
        {
            g = (Game1)game;
            spriteBatch = g.spriteBatch;
            endScreen = g.Content.Load<Texture2D>("Images/GameScreens/EndScreen");
            font = g.Content.Load<SpriteFont>("Fonts/LivesAndScore");
            backgroundMusic = g.Content.Load<Song>("Music/Game Over");
            

        }

        public override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            spriteBatch.Draw(endScreen, Vector2.Zero, Color.White);
            spriteBatch.DrawString(font, Shared.gameScore.ToString() + " Seconds", 
                new Vector2(Shared.stage.X / 2  - font.MeasureString(Shared.gameScore.ToString() + "Seconds").Length() / 2, 
                Shared.stage.Y / 2), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
