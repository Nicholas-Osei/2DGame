using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public class Bullet 
    {
       
        public Texture2D Texture;
        public  Vector2 PositionBullet,VelocityBullet,OriginBullet;
        public bool Zichtbaar;
        public Rectangle ColliBullet;
        public Bullet(Texture2D _texture, Vector2 position)
        {
            Texture = _texture;
            PositionBullet = position;
            Zichtbaar = false;
            ColliBullet = new Rectangle((int)PositionBullet.X, (int)PositionBullet.Y, 92, 41);
        }
        public void Update(GameTime gameTime)
        {
            ColliBullet.X = (int)PositionBullet.X;
            ColliBullet.Y = (int)PositionBullet.Y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionBullet, null, Color.White, 0f, OriginBullet, 1f, SpriteEffects.None, 0);
        }

    }
}
