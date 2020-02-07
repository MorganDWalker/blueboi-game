/*
 * Morgan Walker
 * The player class that handles input from the player and draws the sprite
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blueboi.PlayerClasses
{
    public class Player : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Texture2D idlePlayer;
        private Texture2D jumpAnimation;
        private Texture2D freeFallAnimation;
        private Texture2D landAnimation;
        private Texture2D tempTex;

        private TimeSpan timeSpan;
        private List<Rectangle> frames;
        private int frameCount;
        private int frameIndex = -1;
        private int delay = 2;
        private int delayCounter = 0;
        private int lifeCount = 3;

        private Vector2 position;
        private Vector2 dimension;
        private Vector2 speed;

        private bool hasJumped;
        private bool fallAnimationActive;


        public Vector2 Position { get => position; set => position = value; }
        public Texture2D Tex { get => tex; set => tex = value; }
        public Vector2 Speed { get => speed; set => speed = value; }

        public Player(Game game,
            SpriteBatch spriteBatch,
            Texture2D idlePlayer,
            Texture2D jumpAnimation,
            Texture2D freeFallAnimation,
            Texture2D landAnimation,
            Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.idlePlayer = idlePlayer;
            this.jumpAnimation = jumpAnimation;
            this.freeFallAnimation = freeFallAnimation;
            this.landAnimation = landAnimation;
            this.position = position;
            this.speed = new Vector2(0, 0);
            frameCount = 0;
            Shared.playerHealth = lifeCount;
        }

        /// <summary>
        /// Create the frames for the current animation
        /// </summary>
        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < frameCount; i++)
            {
                    int x = i * (int)dimension.X;
                    int y = 0;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);

                    frames.Add(r);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // checks to see if an animation is being played
            // if there is it sets the tex based on framecount
            if (frameIndex >= 0)
            {
                if (frameCount == 14)
                {
                    tex = jumpAnimation;
                }
                else if(frameCount == 24)
                {
                    tex = freeFallAnimation;
                }
                else if(frameCount == 15)
                {
                    tex = landAnimation;
                }

                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
                
            }
            else
            {
                tex = idlePlayer;
                spriteBatch.Draw(tex, position, Color.White);
            }
            

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            // Keeps the score
            timeSpan += gameTime.ElapsedGameTime;
            Shared.gameScore = (float)timeSpan.TotalSeconds;

            // Keeps track of player health
            lifeCount = Shared.playerHealth;
            // Sets speed
            position += speed;
            speed.X = 0;

            KeyboardState ks = Keyboard.GetState();

            // causes player to jump when space is pressed
            if (ks.IsKeyDown(Keys.Space) && hasJumped == false)
            {
                frameIndex = 0;
                frameCount = 14;
                tempTex = jumpAnimation;
                dimension = new Vector2(tempTex.Width / frameCount, tempTex.Height);
                createFrames();
                position.Y -= 10f;
                speed.Y = -5f;
                hasJumped = true;

            }
            // when the speed.Y is greater then 0 it activates the freefall animation
            if (speed.Y > 0 && fallAnimationActive == false)
            {
                frameIndex = 0;
                frameCount = 24;
                tempTex = freeFallAnimation;
                dimension = new Vector2(tempTex.Width / frameCount, tempTex.Height);
                createFrames();
                fallAnimationActive = true;
            }

            // slowly adds to the y so player floats back down
            if (hasJumped == true)
            {
                speed.Y += 0.145f;
            }

            // stops player descent on ground
            if (position.Y >= 200)
            {
                if (hasJumped == true)
                {
                    fallAnimationActive = false;
                    frameIndex = 0;
                    frameCount = 15;
                    tempTex = landAnimation;
                    dimension = new Vector2(tempTex.Width / frameCount, tempTex.Height);
                    createFrames();
                    hasJumped = false;
                }
                
            }

            if (hasJumped == false)
            {
                speed.Y = 0f;
            }
            
            if (frameCount != 0)
            {
                delayCounter++;
                if (delayCounter > delay)
                {
                    frameIndex++;
                    if (frameIndex > frameCount - 1)
                    {

                        frameIndex = -1;
                        frameCount = 0;
                        frames.Clear();
                        tex = idlePlayer;

                    }

                    delayCounter = 0;
                }
                
            }
            

            base.Update(gameTime);
        }

        public Rectangle getBound()
        {
            // if animation is active gets the bounds of the frame
            if (frameCount != 0 && frameIndex >= 0)
            {
                
                return new Rectangle((int)position.X, (int)position.Y, tex.Width / frameCount, tex.Height);
            }
            else
            {
                return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
            }
            
        }
    }
}
