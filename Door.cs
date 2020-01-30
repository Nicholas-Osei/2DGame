using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public class Door
    {
        readonly Texture2D door;
        public Rectangle Colli;
        readonly Map map;
        public Vector2 vector = new Vector2(5050, 900);
        public Door(Texture2D _door)
        {
            map = new Map();
            door = _door;
            Colli = new Rectangle(5050, 900, 128, 96);
        }
        public void  Draw(SpriteBatch sprite)
        {
          sprite.Draw(door, vector, new Rectangle(0, 0, 128, 96), Color.Wheat);
        }
    }
}
