/*
 * Morgan Walker
 * Scene to display the start menu
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
using Blueboi.Components;

namespace Blueboi.Scenes
{
    public class StartScene : Scene
    {
        private MenuComponent menu;
        private SpriteBatch spriteBatch;
        string[] menuItems = {"Start Game",
        "Help",
        "Credit",
        "Quit"};

        public StartScene(Game game) : base(game)
        {

            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            //load the resources
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("Fonts/HighlightFont");
            backgroundMusic = g.Content.Load<Song>("Music/Theme");

            menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(menu);

        }

        public MenuComponent Menu { get => menu; set => menu = value; }
    }

}
