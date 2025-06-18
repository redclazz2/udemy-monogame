using System;
using System.Formats.Asn1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg
{
    public class Controller
    {
        public static double timer = 2D;
        public static double maxTime = 2D;

        static Random rand = new Random();

        public static void Update(GameTime gameTime, Texture2D enemySprite)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                int side = rand.Next(4);

                switch (side)
                {
                    case 0:
                        Enemy.enemies.Add(new Enemy(new Vector2(-500, rand.Next(-500, 2000)), enemySprite));
                        break;

                    case 1:
                        Enemy.enemies.Add(new Enemy(new Vector2(2000, rand.Next(-500, 2000)), enemySprite));
                        break;

                    case 2:
                        Enemy.enemies.Add(new Enemy(new Vector2(rand.Next(-500, 2000), -500), enemySprite));
                        break;

                    case 3:
                        Enemy.enemies.Add(new Enemy(new Vector2(rand.Next(-500, 2000), 2000), enemySprite));
                        break;
                }

                //Enemy.enemies.Add(new Enemy(new Vector2(100, 100), enemySprite));
                timer = maxTime;

                if (maxTime > 0.5)
                {
                    maxTime -= 0.05D;
                }
            }
        }
    }
}