using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Blueboi.Scenes;

namespace Blueboi.LogClasses
{
    public class Log : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Game1 g;
        int logType;
        
        

        public Vector2 Position { get => position; set => position = value; }

        public Log(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            int logType) : base(game)
        {
            this.g = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.logType = logType;
            this.speed = new Vector2(5.5f, 0);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            position -= speed;
            base.Update(gameTime);
        }

        public Rectangle getBound()
        {
            if (logType == 1)
            {
                return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
            }
            else
            {
                return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
            }
            
        }
    }
}
