using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Blueboi.Scenes;

namespace Blueboi.Misc
{
    public class Foreground : DrawableGameComponent
    {

        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos1;
        private Vector2 pos2;
        private Vector2 speed;

        public Foreground(Game game, SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            pos1 = new Vector2(0, (Shared.stage.Y / 2) + 100f);
            pos2 = new Vector2(Shared.stage.X, (Shared.stage.Y / 2) + 100f);
            speed = new Vector2(5.5f, 0);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos1, Color.White);
            spriteBatch.Draw(tex, pos2, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            pos1 -= speed;
            pos2 -= speed;

            if (pos1.X < -tex.Width)
            {
                pos1.X = pos2.X + tex.Width;
            }
            if (pos2.X < -tex.Width)
            {
                pos2.X = pos1.X + tex.Width;
            }
            base.Update(gameTime);
        }
    }
}
