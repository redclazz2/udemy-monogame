using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace spaceship
{        
    public class Ship
    {
        private float velocity = 180;
        public Vector2 position = new (100,100);

        public void Update(GameTime gameTime){
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(kState.IsKeyDown(Keys.Right)){
                position.X+= velocity * dt;
            }

            if(kState.IsKeyDown(Keys.Left)){
                position.X-= velocity * dt;
            }

            if(kState.IsKeyDown(Keys.Up)){
                position.Y-= velocity * dt;
            }

            if(kState.IsKeyDown(Keys.Down)){
                position.Y+= velocity * dt;
            }
        }
    }
}