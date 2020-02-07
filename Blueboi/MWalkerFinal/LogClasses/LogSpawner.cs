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
    public class LogSpawner : GameComponent
    {
        private const float MAX_LOGS = 5;

        private int logsOnScreen;

        private const float SPAWN_RATE = 1.25f;
        private float spawnTimer;

       
        private Random random;

        private Texture2D tex;

        private SpriteBatch spriteBatch;

        private Texture2D logTop;

        private Texture2D logBottom;

        private Game1 g;

        private ActionScene actionScene;

        public LogSpawner(Game game, Texture2D logTop, Texture2D logBottom, SpriteBatch spriteBatch, ActionScene actionScene) : base(game)
        {
            this.g = (Game1)game;
            this.logTop = logTop;
            this.logBottom = logBottom;
            this.spriteBatch = g.spriteBatch;
            this.random = new Random();
            this.actionScene = actionScene;

        }

        private void spawnPlatform(float gameTime)
        {
            spawnTimer += gameTime;
            int logType = random.Next(1, 3);
            Vector2 startPos = new Vector2(0,0);
            if (logType == 1)
            {
                startPos = new Vector2(Shared.stage.X, 0);
                tex = logTop;
            }
            else if (logType == 2)
            {
                startPos = new Vector2(Shared.stage.X, 275);
                tex = logBottom;
            }
            
            if (spawnTimer > SPAWN_RATE && logsOnScreen < MAX_LOGS)
            {
                var log = new Log(g, spriteBatch, tex, startPos, logType);

                actionScene.Components.Add(log);
                Shared.logsOnScreen++;
                spawnTimer = 0;
            }

            
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            logsOnScreen = Shared.logsOnScreen;

            spawnPlatform(time);
            Console.WriteLine($"current platforms {logsOnScreen}");

            base.Update(gameTime);
        }
    }
}
