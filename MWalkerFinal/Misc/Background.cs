using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blueboi.Misc
{
    public class Background : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 speed;
        private Vector2 pos, pos2;
        

        public Background(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.speed = speed;
            this.pos = new Vector2(0,0);

            this.pos2 = new Vector2(pos.X + tex.Width, pos.Y);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, pos, Color.White);
            spriteBatch.Draw(tex, pos2, Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            pos -= speed;
            pos2 -= speed;

            if (pos.X < -tex.Width)
            {
                pos.X = pos2.X + tex.Width;
            }
            if (pos2.X < -tex.Width)
            {
                pos2.X = pos.X + tex.Width;
            }
            base.Update(gameTime);
        }
    }
}
