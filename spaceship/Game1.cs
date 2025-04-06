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
    Asteroid testAsteroid = new(250);

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

        player.Update(gameTime);
        testAsteroid.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(spaceSprite, new Vector2(0,0), Color.White);
        _spriteBatch.Draw(shipSprite, player.position -  new Vector2(34,50), Color.White);
        _spriteBatch.Draw(asteroidSprite, testAsteroid.position - new Vector2(testAsteroid.radius, testAsteroid.radius),Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
