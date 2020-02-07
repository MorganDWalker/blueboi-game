using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueboi.Scenes
{
    public class CreditScene : Scene
    {
        private SpriteBatch spriteBatch;
        private Texture2D creditScreen;

        public CreditScene(Game game) : base(game)
        {

            g = (Game1)game;
            spriteBatch = g.spriteBatch;

            backgroundMusic = g.Content.Load<Song>("Music/Theme");
            creditScreen = g.Content.Load<Texture2D>("Images/GameScreens/creditScreen");

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(creditScreen, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
