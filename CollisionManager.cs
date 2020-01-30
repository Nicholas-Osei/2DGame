using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    class CollisionManager
    {
        Color backgroundColor = Color.CornflowerBlue;
        public bool Update(Soldier p1, Blockken p2)
        {
            //if (p1.CollisionRectangle.Intersects(p2.Rectangle))
            //{
            //    backgroundColor = Color.White;
            //    p1.position = new Vector2(0, 100);
            //    return true;
            //}

            return false;
        }
    }
}
