using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace spaceship;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D shipSprite;
    Texture2D asteroidSprite;
    Texture2D spaceSprite;

    SpriteFont gameFont;
    SpriteFont timerFont;

    Ship player = new();

    Controller controller = new();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        shipSprite = Content.Load<Texture2D>("ship");
        asteroidSprite = Content.Load<Texture2D>("asteroid");
        spaceSprite = Content.Load<Texture2D>("space");

        gameFont = Content.Load<SpriteFont>("spaceFont");
        timerFont = Content.Load<SpriteFont>("timerFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        controller.PlayerUpdate(gameTime);
        controller.CounterUpdate(gameTime);
        controller.AsteroidUpdate(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(spaceSprite, new Vector2(0,0), Color.White);
        controller.AsteroidDraw(asteroidSprite,_spriteBatch);
        _spriteBatch.Draw(shipSprite, controller.ship.position -  new Vector2(34,50), Color.White);
        
        if(!controller.inGame){
            string menuMessage = "PRESS ENTER TO BEGIN";
            //This gives u the W/H of the string when drawn to screen
            Vector2 sizeOfText = gameFont.MeasureString(menuMessage);
            
            int hW = _graphics.PreferredBackBufferWidth/2;

            _spriteBatch.DrawString(gameFont,menuMessage, new Vector2(hW - sizeOfText.X / 2, 200),Color.White);
        }
        
        _spriteBatch.DrawString(timerFont, "TIME: " + Math.Floor(controller.totalTime), new Vector2(100,100), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
