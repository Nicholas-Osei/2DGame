using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game9
{
    public class Tile
    {
        protected Texture2D texture;
        public Rectangle Rectangle { get; protected set; }
        private static ContentManager content;
        public static ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }

    }
}
