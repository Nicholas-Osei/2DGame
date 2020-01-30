using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game9
{
    public class GameScreen
    {
        protected ContentManager content;
        [XmlIgnore]
        public Type Type;
        public string xmlPath;
        public GameScreen()
        {
            Type = this.GetType();
            xmlPath = "Load/"+Type.ToString().Replace("Game9.", "") + ".xml";
        }
        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void  Update(GameTime gametime)
        {
            KeyboardClass.Instance.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
