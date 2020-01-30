using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;
namespace Game9
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        [XmlIgnore]
        public Vector2 Dimension { private set;  get; }
        [XmlIgnore]
        public ContentManager Content { private set; get; }
        XmlManager<GameScreen> xmlGamescreenManager;

        public  GameScreen currentScreen,newScreen;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        public Image Image;
        [XmlIgnore]
        public bool IsTransitioning { get; private set; }
      
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("Load/ScreenManager.xml");
                }
                return instance;
            }
        }
        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Game9." + screenName));
            Image.isActive = true;
            Image.Fadeeffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }
        void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Image.Update(gameTime);
                if (Image.Alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    xmlGamescreenManager.Type = currentScreen.Type;
                    if (File.Exists(currentScreen.xmlPath))
                    {
                        currentScreen = xmlGamescreenManager.Load(currentScreen.xmlPath);
                    }
                    currentScreen.LoadContent();
                }
                else if (Image.Alpha==0.0f)
                {
                    Image.isActive = false;
                    IsTransitioning = false;
                }
            }
        }
        public ScreenManager()
        {
            Dimension = new Vector2(1920, 1080);
            currentScreen = new SplashScreen();
            xmlGamescreenManager = new XmlManager<GameScreen>
            {
                Type = currentScreen.Type
            };
            currentScreen = xmlGamescreenManager.Load("Load/SplashScreen.xml");
        }
        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }
        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            if (!IsTransitioning)
            {
                currentScreen.Update(gameTime);
            }
            else
            {
                Transition(gameTime);
            }
           Camera.Instance.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
            {
                Image.Draw(spriteBatch);
            }
        }

    }
}
