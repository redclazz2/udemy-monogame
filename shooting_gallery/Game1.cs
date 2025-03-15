using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace shooting_gallery;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private const int targetRadius = 45;
    private Texture2D _targetSprite;
    private Texture2D _crosshairsSprite;
    private Texture2D _backgroundSprite;

    private SpriteFont _gameFont;

    private Vector2 targetPosition = new (300,300);
    int score = 0;
    double timer = 10;

    private MouseState mouseState;
    private bool mReleased = true;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    //Executes when the game first initializes. 
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    //Load images, sounds and other content for the game.
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //When loading assets u dont need to specify the extension of the file
        _targetSprite     = Content.Load<Texture2D>("target");
        _crosshairsSprite = Content.Load<Texture2D>("crosshairs");
        _backgroundSprite = Content.Load<Texture2D>("sky");

        _gameFont = Content.Load<SpriteFont>("galleryFont");
    }

    //This IS the gameloop. By default it runs 60 times per second
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if(timer > 0){
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
        }else if(timer < 0){
            timer = 0;
        }

        /*
        To get the user's input you can access the state of input methods.
        For example, for a frame, you'll get the current state of the mouse.
        */

        mouseState = Mouse.GetState();

        if(mouseState.LeftButton == ButtonState.Pressed && mReleased){
            float mouseTargetDis = Vector2.Distance(targetPosition, mouseState.Position.ToVector2());
            
            if(mouseTargetDis < targetRadius && timer > 0){
                score++;
                Random rnd = new();
                targetPosition.X = rnd.Next(0,_graphics.PreferredBackBufferWidth);
                targetPosition.Y = rnd.Next(0,_graphics.PreferredBackBufferHeight);
            }

            mReleased = false;
        }

        if(mouseState.LeftButton == ButtonState.Released){
            mReleased = true;
        }

        base.Update(gameTime);
    }
    
    //Here we write anything that needs drawing in the game. DO NOT put any calculations!
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //Spritebatch: Tool provided by monogame to draw things to the screen.
        _spriteBatch.Begin(); //We're about to draw!        
        _spriteBatch.Draw(_backgroundSprite, new Vector2(0,0),Color.White);

        //We need to modify the target position due to the image's origin being the topleft corner
        if(timer > 0){
            _spriteBatch.Draw(_targetSprite, targetPosition - new Vector2(targetRadius,targetRadius), Color.White);
            _spriteBatch.DrawString(_gameFont, "Time: " +  Math.Ceiling(timer), new Vector2(20,0),Color.White);
            _spriteBatch.DrawString(_gameFont,"Score: " +  score,new Vector2(320,0) ,Color.White);

            _spriteBatch.Draw(_crosshairsSprite, new Vector2(mouseState.X - 25, mouseState.Y - 25), Color.White);
        }else{
            _spriteBatch.DrawString(_gameFont, "GAME OVER! SCORE: " + score, 
                new Vector2(120, _graphics.PreferredBackBufferHeight/2), Color.White);
        }
        
        _spriteBatch.End(); //We're done!

        //In between being and end u can have multiple draw calls.

        base.Draw(gameTime);
    }
}
