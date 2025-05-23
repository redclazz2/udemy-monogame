using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace spaceship
{        
    public class Ship
    {
        static public Vector2 defaultPosition = new Vector2(640,360);
        private float velocity = 180;
        public Vector2 position = defaultPosition;
        public int radius = 30;

        public void Update(GameTime gameTime){
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(kState.IsKeyDown(Keys.Right) && position.X < 1280){
                position.X+= velocity * dt;
            }

            if(kState.IsKeyDown(Keys.Left) && position.X > 0){
                position.X-= velocity * dt;
            }

            if(kState.IsKeyDown(Keys.Up) && position.Y > 0){
                position.Y-= velocity * dt;
            }

            if(kState.IsKeyDown(Keys.Down) && position.Y < 720){
                position.Y+= velocity * dt;
            }
        }
    }
}