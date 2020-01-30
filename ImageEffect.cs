using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public class ImageEffect
    {
        protected Image image;
        public bool isActive;
        public ImageEffect()
        {
            isActive = false;
        }
        public virtual void LoadContent(ref Image Image)
        {
            this.image = Image;
        }
        public virtual void UnloadContent()
        { 

        }
        public virtual void Update(GameTime gameTime)
        {
;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
