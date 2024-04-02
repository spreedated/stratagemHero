using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using StratagemHero.Logic;

namespace StratagemHeroMonoCross
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SimpleFps _fps;
        private Texture2D whiteRectangle;

        public Game1()
        {
            this._graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 520,
                PreferredBackBufferWidth = 1095,
                IsFullScreen = false
            };
            base.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            base.Window.Title = "Stratagem Hero";
            base.IsFixedTimeStep = false;
            base.Window.AllowUserResizing = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this._fps = new();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this._spriteBatch = new SpriteBatch(base.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals.FontInsignia = base.Content.Load<SpriteFont>("Fonts\\Insignia");
            Globals.FontInsigniaBmp = base.Content.Load<BitmapFont>("Fonts\\InsigniaBmp");

            this.whiteRectangle = new Texture2D(base.GraphicsDevice, 1, 1);
            this.whiteRectangle.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                base.Exit();
            }

            // TODO: Add your update logic here
            this._fps.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.GraphicsDevice.Clear(Constants.ColorGrey);

            this._spriteBatch.Begin();

            this._spriteBatch.Draw(this.whiteRectangle, new Rectangle(0, 48, this._graphics.PreferredBackBufferWidth, 8), Constants.ColorWhite);

            this._spriteBatch.DrawString(Globals.FontInsigniaBmp, "STRATAGEM HERO", new Vector2((this._graphics.PreferredBackBufferWidth / 2) - (Globals.FontInsignia.MeasureString("STRATAGEM HERO").X / 2), (this._graphics.PreferredBackBufferHeight / 2) - (Globals.FontInsignia.MeasureString("STRATAGEM HERO").Y / 2)), Constants.ColorWhite, 0f, new Vector2(), 2, SpriteEffects.None, 0f);
            this._spriteBatch.DrawString(Globals.FontInsigniaBmp, "Enter any Stratagem Input to Start!", new Vector2((this._graphics.PreferredBackBufferWidth / 2) - (Globals.FontInsignia.MeasureString("Enter any Stratagem Input to Start!").X / 2) + 20, 32f), Constants.ColorYellow);
            
            this._spriteBatch.Draw(this.whiteRectangle, new Rectangle(0, this._graphics.PreferredBackBufferHeight - 48, this._graphics.PreferredBackBufferWidth, 8), Constants.ColorWhite);

            this._spriteBatch.End();

            // TODO: Add your drawing code here
            this._fps.DrawFps(this._spriteBatch, Globals.FontInsignia, new Vector2(10f, 10f), Color.Gray);

            base.Draw(gameTime);
        }
    }
}
