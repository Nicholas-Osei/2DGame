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
    class PauseScreen:GameScreen
    {
        MenuManager menuManager;
        public PauseScreen()
        {
            menuManager = new MenuManager();
        }
        public override void LoadContent()
        {
            base.LoadContent();
            menuManager.LoadContent("Load/Pause.xml");
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            menuManager.UnloadContent();
        }
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            menuManager.Update(gametime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
        }
    }
}


