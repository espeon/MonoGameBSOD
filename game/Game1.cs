using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        //defaults
        float rotation = 0.0f;
        Vector2 origin = new Vector2(0, 0);
        Vector2 TTFOrigin;
        SpriteEffects spriteEffect = SpriteEffects.None;
        float zDepth = 0.1f;
        float scale = 1f;

        Rectangle drawRec;

        SpriteFont PixelFont;
        Texture2D Bing;

        public Game1()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            _graphicsDeviceManager.PreferredBackBufferWidth = 1280;
            _graphicsDeviceManager.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            PixelFont = Content.Load<SpriteFont>("Pokemon Classic");
            Bing = Content.Load<Texture2D>(@"bing");
            drawRec = new Rectangle(0, 0, Bing.Width, Bing.Height);
        }

        protected override void UnloadContent()
        {
            _spriteBatch.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.F))
            {
                if (_graphicsDeviceManager.IsFullScreen == true)
                    _graphicsDeviceManager.IsFullScreen = false;
                else
                    _graphicsDeviceManager.IsFullScreen = true;
                _graphicsDeviceManager.ApplyChanges();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Color BsodBlue = new Color(0, 121, 216);
            GraphicsDevice.Clear(BsodBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.DrawString(PixelFont,
                ":(",
                new Vector2(100, 150),
                Color.White,
                rotation,
                TTFOrigin,
                5.0f,
                spriteEffect,
                zDepth);
            _spriteBatch.DrawString(PixelFont,
                "Your PC ran into a problem and needs to restart. We're\njust collecting some error info, and then we'll restart for\nyou.",
                new Vector2(100, 300), 
                Color.White);
            _spriteBatch.DrawString(PixelFont,
                "30% complete",
                new Vector2(100, 450),
                Color.White);
            _spriteBatch.Draw(
                Bing,
                new Vector2(100, 550),
                drawRec,
                Color.White,
                rotation,
                origin,
                0.70f,
                spriteEffect,
                zDepth);
            _spriteBatch.DrawString(PixelFont,
                "For more information about this issue and possible fixes, visit https://windows.com/stopcode",
                new Vector2(200, 550),
                Color.White,
                rotation,
                TTFOrigin,
                0.75f,
                spriteEffect,
                zDepth);
            _spriteBatch.DrawString(PixelFont,
                "If you call a support person, give them this info:\nStop code: CRITICAL_PROCESS_DIED",
                new Vector2(200, 600),
                Color.White,
                rotation,
                TTFOrigin,
                0.75f,
                spriteEffect,
                zDepth);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
