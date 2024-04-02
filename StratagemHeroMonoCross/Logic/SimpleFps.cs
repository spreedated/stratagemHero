using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace StratagemHero.Logic
{
    public class SimpleFps
    {
        public double Frames { get; private set; }
        public double Updates { get; private set; }
        public double Elapsed { get; private set; }
        public double Last { get; private set; }
        public double Now { get; private set; }
        public double MsgFrequency { get; private set; } = 10d;
        public string VerboseOutputMessage
        {
            get
            {
                return $"Fps: {this.Frames / this.Elapsed}\nElapsed time: {this.Elapsed}\nUpdates: {this.Updates}\nFrames: {this.Frames}";
            }
        }
        public string OutputMessage
        {
            get
            {
                return $"Fps: {Math.Floor(this.Frames / this.Elapsed)}";
            }
        }

        /// <summary>
        /// The MsgFrequency here is the reporting time to update the message.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            this.Now = gameTime.TotalGameTime.TotalSeconds;
            this.Elapsed = this.Now - this.Last;
            if (this.Elapsed > this.MsgFrequency)
            {
                this.Elapsed = 0;
                this.Frames = 0;
                this.Updates = 0;
                this.Last = this.Now;
            }
            this.Updates++;
        }

        public void DrawFps(SpriteBatch spriteBatch, SpriteFont font, Vector2 fpsDisplayPosition, Color fpsTextColor)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, this.OutputMessage, fpsDisplayPosition, fpsTextColor);
            spriteBatch.End();
            this.Frames++;
        }
    }
}
