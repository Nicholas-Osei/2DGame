using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game9
{
    public class MainMenu:IAssemble
    {
        public event EventHandler MenuChanging; //trigger om iets te doen
        public string Axis;
        public string Effects;
        [XmlElement("Item")]
        public List<MenuItem> Items;
        public int Itemnummer { get;  set; }
        private string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                MenuChanging(this, null);
            }
        }
        public void Transitioning(float alpha)
        {
            foreach (MenuItem item in Items)
            {
                item.Image.isActive = true;
                item.Image.Alpha = alpha;
                if (alpha==0.0f)
                {
                    item.Image.Fadeeffect.Increase = true;
                }
                else
                {
                    item.Image.Fadeeffect.Increase = false;
                }
            }
        }
        private void AlignMenu()
        {
            Vector2 dimension = Vector2.Zero;
            foreach (MenuItem item in Items)
            {
                dimension += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);
            }
            dimension = new Vector2((ScreenManager.Instance.Dimension.X - dimension.X) / 2, (ScreenManager.Instance.Dimension.Y - dimension.Y) / 2);

            foreach (MenuItem item in Items)
            {
                if (Axis == "X")
                {
                    item.Image.Position = new Vector2(dimension.X, (ScreenManager.Instance.Dimension.Y - item.Image.SourceRect.Height) / 2);
                }
                else if (Axis == "Y")
                {
                    item.Image.Position = new Vector2((ScreenManager.Instance.Dimension.X - item.Image.SourceRect.Width) / 2, dimension.Y);
                }
                dimension += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);
            }
        }
        public MainMenu()
        {
            id = String.Empty;
            Itemnummer = 0;
            Effects = String.Empty;
            Axis = "Y";
            Items = new List<MenuItem>();
        }
        public void LoadContent()
        {
            string[] seperate = Effects.Split(':');
            foreach (MenuItem item in Items)
            {
                item.Image.LoadContent();
                foreach (string p in seperate)
                {
                    item.Image.ActivateEffect(p);
                }
            }
            AlignMenu();
        }
        public void UnloadContent()
        {
            foreach (MenuItem item in Items)
            {
                item.Image.UnloadContent();
            }
        }
        public  void Update(GameTime gameTime)
        {
            if (Axis == "X")
            {
                if (KeyboardClass.Instance.KeyPressed(Keys.Right))
                {
                    Itemnummer++;
                }
                else if (KeyboardClass.Instance.KeyPressed(Keys.Left))
                {
                    Itemnummer--;
                }
            }
            else if (Axis == "Y")
            {
                if (KeyboardClass.Instance.KeyPressed(Keys.Down))
                {
                    Itemnummer++;
                }
                else if (KeyboardClass.Instance.KeyPressed(Keys.Up))
                {
                    Itemnummer--;
                }
            }
            if (Itemnummer <0)
            {
                Itemnummer = 0;
            }
            else if(Itemnummer > Items.Count-1)
            {
                Itemnummer = Items.Count - 1;
            }
            for (int i = 0; i < Items.Count; i++)
            {
                if (i==Itemnummer)
                {
                    Items[i].Image.isActive = true;
                }
                else
                {
                    Items[i].Image.isActive = false;
                }
                Items[i].Image.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in Items)
            {
                item.Image.Draw(spriteBatch);
            }
        }
    }
}
