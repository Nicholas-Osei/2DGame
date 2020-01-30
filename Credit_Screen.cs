using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game9
{
    public class Credit_Screen: GameScreen,IAssemble
    {
        public SpriteFont font;
        public override void Draw(SpriteBatch spriteBatch) // /t werkt niet ?
        {
            spriteBatch.DrawString(font, "                     Gemaakt  door NICHOLAS OSEI.\n" +
                " Met  behulp van Tom Peteers,Coding Master,Oyou,Stack- \n" +
                " overflow, Google en Youtube heb  ik deze Game kunnen \n " +
                " maken. Ik Bedank jullie  allemaal enorm. Het is altijd \n" +
                "  mijn droom geweest om een Spel te  maken. Nu heb ik \n " +
                " dit gerealiseerd! Tot Volgende Keer ! :) \n\n                                       2019-2020" +
                "\n\n\n          Druk op de  Spatiebalk om terug te gaan "
                , new Vector2(100, 150), Color.White);
        }
        public override void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "content");
            font = content.Load<SpriteFont>("Timer");
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
