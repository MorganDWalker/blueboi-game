/*
 * Morgan Walker 
 * Scene to display the actual gameplay
 */
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Blueboi.Components;
using Blueboi.LogClasses;
using Blueboi.Misc;
using Blueboi.PlayerClasses;
using Blueboi.Text;

namespace Blueboi.Scenes
{
    public class ActionScene : Scene
    {
        private SpriteBatch spriteBatch;

        public ActionScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            backgroundMusic = g.Content.Load<Song>("Music/Forest Frenzy");
            
            // Load all the resources needed
            Texture2D idlePlayer = g.Content.Load<Texture2D>("Images/PlayerSprites/placeholderBoi");
            Texture2D freeFallSprite = g.Content.Load<Texture2D>("Images/PlayerSprites/freefallSpriteSheet");
            Texture2D jumpSprite = g.Content.Load<Texture2D>("Images/PlayerSprites/jumpSpritesheet");
            Texture2D landSprite = g.Content.Load<Texture2D>("Images/PlayerSprites/landSpritesheet");

            Texture2D logTop = g.Content.Load<Texture2D>("Images/LogSprites/TopLog");
            Texture2D logBottom = g.Content.Load<Texture2D>("Images/LogSprites/LogBottom");

            Texture2D layer0 = g.Content.Load<Texture2D>("Images/GameBackgrounds/0");
            Texture2D layer1 = g.Content.Load<Texture2D>("Images/GameBackgrounds/1");
            Texture2D layer2 = g.Content.Load<Texture2D>("Images/GameBackgrounds/2");
            Texture2D layer3 = g.Content.Load<Texture2D>("Images/GameBackgrounds/3");
            Texture2D foregroundImage = g.Content.Load<Texture2D>("Images/Foreground/foreground");
            SpriteFont healthFont = g.Content.Load<SpriteFont>("Fonts/LivesAndScore");

            // Set position for player
            Vector2 pos = new Vector2(10, (Shared.stage.Y / 2) - 45);

            // Add components to screen
            Background firstLayer = new Background(g, spriteBatch, layer0, new Vector2(0.5f, 0));
            this.Components.Add(firstLayer);
            Background secondLayer = new Background(g, spriteBatch, layer1, new Vector2(1f, 0));
            this.Components.Add(secondLayer);
            Background thirdLayer = new Background(g, spriteBatch, layer2, new Vector2(1.5f, 0));
            this.Components.Add(thirdLayer);
            Background fourthLayer = new Background(g, spriteBatch, layer3, new Vector2(2f, 0));
            this.Components.Add(fourthLayer);

            Collision collision = new Collision(g, this);
            this.Components.Add(collision);

            Foreground foreground = new Foreground(g, spriteBatch, foregroundImage);
            this.Components.Add(foreground);

            Player player = new Player(g, spriteBatch, idlePlayer, jumpSprite, freeFallSprite, landSprite, pos);
            this.Components.Add(player);

            LogSpawner spawner = new LogSpawner(g, logTop, logBottom, spriteBatch, this);
            this.Components.Add(spawner);

            PlayerHealthText healthText = new PlayerHealthText(g, spriteBatch, healthFont);
            this.Components.Add(healthText);

        }
    }
}
