using Microsoft.Xna.Framework;

namespace spaceship
{
    public class Asteroid
    {
        public Vector2 position = new Vector2(600,300);
        public int speed;
        public int radius = 59;

        public Asteroid(int speed){
            this.speed = speed;
        }

        public void Update(GameTime gameTime){
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X -= speed * dt;
        }
    }
}