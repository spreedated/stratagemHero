using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratagemHero.Logic
{
    internal static class DrawStringCenter
    {
        [Flags]
        public enum Alignment
        {
            Center = 0,
            Left = 1,
            Right = 2,
            Top = 4,
            Bottom = 8
        }

        public static void DrawStringCentered(this SpriteBatch spriteBatch, SpriteFont font, string text, Alignment align, Vector2 offset, Color color)
        {
            Vector2 size = font.MeasureString(text);

            switch (align)
            {
                case Alignment.Center:
                    break;
                case Alignment.Left:
                    break;
                case Alignment.Right:
                    break;
                case Alignment.Top:
                    break;
                case Alignment.Bottom:
                    break;
            }
        }
    }
}
