using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

namespace Game9
{
    public class SplashScreen:GameScreen
    {
        
        public Image Image;
        public static int lol = 0;
       // Remote remote;
        public override void LoadContent()
        {
            base.LoadContent();
            //path = "SplashScreen/photo";
            Image.LoadContent();
            //Image.Fadeeffect.FadeSpeed = 0.5f;
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);
            if (KeyboardClass.Instance.KeyPressed(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");

            }

            //    remote.Update();
            //    if (remote.Enter)
            //    {
            //        ScreenManager.Instance.ChangeScreens("SplashScreen");
            //    }

            //if (lol==1)
            //{

            //}
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}
