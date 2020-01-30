using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public class Unpause
    {
        public static bool pausing = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GamePlay.font, "Game is Paused !\n Press L to Resume", new Vector2(Soldier.position.X - 100, 500), Color.Red);
        }
    }
}
