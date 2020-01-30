using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    interface IAssemble
    {
         void Update(GameTime gamTime);
         void Draw(SpriteBatch spriteBatch);
         void UnloadContent();
         void LoadContent();


    }
}
