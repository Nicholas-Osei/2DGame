using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    class Controles_Screen:GameScreen,IAssemble
    {
        private Texture2D controles;
        public override void Draw(SpriteBatch spriteBatch) // /t werkt niet ?
        {
            spriteBatch.Draw( controles, new Rectangle(0,0,(int)ScreenManager.Instance.Dimension.X,(int)ScreenManager.Instance.Dimension.Y),Color.White);
        }
        public override void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "content");
            controles = content.Load<Texture2D>("Controles");
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gametime)
        {
            if (KeyboardClass.Instance.KeyDown(Keys.Space))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
            }
            base.Update(gametime);
        }
    }
}
