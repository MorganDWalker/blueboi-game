using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Blueboi.LogClasses;
using Blueboi.PlayerClasses;
using Blueboi.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueboi.Components
{
    public class Collision : GameComponent
    {
        private Game1 g;
        private ActionScene actionScene;


        public Collision(Game game, ActionScene actionScene) : base(game)
        {
            g = (Game1)game;
            this.actionScene = actionScene;
        }

        private void CheckPlatformCollision()
        {
            foreach(var component in actionScene.Components.ToArray())
            {
                if (component is Player player)
                {
                    foreach (var otherComponent in actionScene.Components.ToArray())
                    {
                        if (otherComponent is Log log)
                        {
                            if (player.getBound().Intersects(log.getBound()))
                            {

                                Console.WriteLine("Player got hit");
                                actionScene.ComponentsToRemove.Add(log);
                                Shared.logsOnScreen--;
                                Shared.playerHealth--;
                            }

                        }
                    }
                }
            }
        }

        private void CheckOutOfBounds()
        {
            foreach (var component in g.Components.ToArray()) 
            {
                if (component is Log log)
                {
                    if(log.Position.X < 0)
                    {
                        actionScene.ComponentsToRemove.Add(log);
                        Shared.logsOnScreen--;
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            CheckPlatformCollision();
            CheckOutOfBounds();

            base.Update(gameTime);
        }
    }
}
