using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace spaceship
{
    public class Controller
    {
        public List<Asteroid> asteroids = [];
        public double timer = 2;
        public double maxTime = 2;
        public int nextSpeed = 250;
        public bool inGame = false;
        public Ship ship = new();
        public double totalTime = 0;
        
        public void PlayerUpdate(GameTime gameTime){
            if(inGame){
                ship.Update(gameTime);
            }
        }
        public void CounterUpdate(GameTime gameTime){
            if(inGame){
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                totalTime += gameTime.ElapsedGameTime.TotalSeconds;
            }else{
                if(Keyboard.GetState().IsKeyDown(Keys.Enter)){
                    inGame=true;
                }
            }
            
            if(timer <=0){
                asteroids.Add(new Asteroid(nextSpeed));
                timer = maxTime;
                if(maxTime > 0.5) maxTime -= 0.1;
                //if(nextSpeed < 300) nextSpeed += 4;
            }
        }
        public void AsteroidUpdate(GameTime gameTime){
            
            for(int i = 0 ; i < asteroids.Count; i ++){
                asteroids[i].Update(gameTime);
                int sum = asteroids[i].radius + ship.radius;
                if(Vector2.Distance(asteroids[i].position, ship.position) < sum){
                    inGame = false;
                    ship.position = Ship.defaultPosition;
                    asteroids.Clear();
                    totalTime = 0;
                    timer = 2;
                    maxTime = 2;
                    nextSpeed = 250;
                }
            }
        }
        public void AsteroidDraw(Texture2D asteroid, SpriteBatch spriteBatch){
            for(int i = 0 ; i < asteroids.Count; i ++){
                Asteroid asteroidi = asteroids[i];
                spriteBatch.Draw(asteroid,
                    new Vector2(asteroidi.position.X - asteroidi.radius, asteroidi.position.Y - asteroidi.radius), Color.White);
            }
        }
    }
}