/*
 * Morgan Walker
 * Class to create the menu options
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blueboi.Components
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, highlightFont;
        private List<string> menuItems;
        private int selectedIndex = 0;
        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color highlightColor = Color.Red;
        private KeyboardState oldState;

        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont highlightFont,
            string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;

            menuItems = menus.ToList();
            position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (selectedIndex == i)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[i],
                        new Vector2(tempPos.X - highlightFont.MeasureString(menuItems[i]).Length() / 2, tempPos.Y - 100),
                        highlightColor);
                    tempPos.Y += highlightFont.LineSpacing + 17;
                }
                else
                {

                    spriteBatch.DrawString(regularFont, menuItems[i],
                        new Vector2(tempPos.X - regularFont.MeasureString(menuItems[i]).Length() / 2, tempPos.Y - 100),
                        regularColor);
                    tempPos.Y += regularFont.LineSpacing + 15;
                }
            }


            spriteBatch.DrawString(highlightFont, "Blueboi",
                new Vector2(Shared.stage.X / 2 - highlightFont.MeasureString("Blueboi").Length() / 2, 50), regularColor);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }
            oldState = ks;
            base.Update(gameTime);
        }
    }
}