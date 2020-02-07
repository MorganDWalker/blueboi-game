using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blueboi.Text
{
    public class PlayerHealthText : DrawableGameComponent
    {
        private Game1 g;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 pos;

        public PlayerHealthText(Game game, 
            SpriteBatch spriteBatch,
            SpriteFont font) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.font = font;
            pos = new Vector2(0, (Shared.stage.Y / 2) + 150f);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, $"Hitpoints: {Shared.playerHealth}", pos, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
