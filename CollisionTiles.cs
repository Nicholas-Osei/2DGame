
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game9
{
    class CollisionTiles :Tile
    {
        public CollisionTiles(int i, Rectangle rect)
        {
            texture = Content.Load<Texture2D>("block" + i);
            this.Rectangle = rect;
        }
    }
}
