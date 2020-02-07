/*
 * Morgan Walker
 * Class that all the game scenes inherit from to make creating easier
 */
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Blueboi.Components;
using Blueboi.Misc;
using Blueboi.PlayerClasses;

namespace Blueboi.Scenes
{
    public class Scene : DrawableGameComponent
    {
        protected Game1 g;
        public List<GameComponent> Components { get; private set; }
        public List<GameComponent> ComponentsToRemove { get; private set; }
        protected Song backgroundMusic;

        public Scene(Game game) : base(game)
        {
            g = (Game1)game;
            this.Components = new List<GameComponent>();
            this.ComponentsToRemove = new List<GameComponent>();

            
        }


        public void PlayMusic()
        {
            if (backgroundMusic != null)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.2f;
                MediaPlayer.Play(backgroundMusic);
            }
        }

        public void Hide(bool isActive)
        {
            foreach (var component in Components)
            {
                component.Enabled = !isActive;

                if (component is DrawableGameComponent drawableComponent)
                {
                    drawableComponent.Visible = !isActive;
                }
            }

            Enabled = Visible = !isActive;
        }

        public override void Update(GameTime gameTime)
        {
            // removes the components in ComponentsToRemove from Components
            foreach (var component in ComponentsToRemove)
            {
                if (Components.Contains(component))
                {
                    Components.Remove(component);
                }

                if (g.Components.Contains(component))
                {
                    g.Components.Remove(component);
                }
            }

            ComponentsToRemove.Clear();


            foreach (var component in Components)
            {
                if (!g.Components.Contains(component))
                {
                    g.Components.Add(component);
                }
            }

            base.Update(gameTime);
        }
    }
}
