/*
 * Morgan Walker
 * Scene to display game controls
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
    public class HelpScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpScreen;

        public HelpScene(Game game) : base(game)
        {

            g = (Game1)game;
            spriteBatch = g.spriteBatch;

            backgroundMusic = g.Content.Load<Song>("Music/Theme");
            helpScreen = g.Content.Load<Texture2D>("Images/GameScreens/helpScreen");
            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpScreen, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
