using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public  class Limit_Timer
    {
        SpriteFont font;
        public static int counter = 1;
        private readonly float countDuration = 200f; //every  2s.
        float currentTime = 0f;
        readonly float GoUp = 2f;
        public static float timer = 0f;
        public void LoadContent(SpriteFont _font)
        {
           font = _font;
        }
        public void Timer(GameTime gametime)
        {
            timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            currentTime += (float)gametime.ElapsedGameTime.TotalSeconds; //Time passed since last Update() 
            Console.WriteLine($"time : {(int)timer}");
            if (currentTime >= GoUp)
            {
                counter++;
                currentTime -= GoUp;
            }
            if (currentTime >= countDuration)
            {
                currentTime -= countDuration; // "use up" the time  
            }
            Console.WriteLine($"Counter: {counter}");
            if ((int)timer == 300)
            {
                GamePlay.Dead = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if ((int)timer>280)
            {
                color = Color.Red;
            }
            if ((int)timer >=70 && (int)timer < 80 || (int)timer >= 140 && (int)timer < 150 || (int)timer >= 170)
            {
                color = Color.Green;
            }
            spriteBatch.DrawString(font, "TIME : "+timer.ToString("0"), new Vector2(Soldier.position.X, 10), color);
        }
    }
}
