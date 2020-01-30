using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game9
{
    class MenuManager
    {
        MainMenu mainMenu;
        bool isTransitioning;
        private void Transitioning(GameTime gameTime)
        {
            if (isTransitioning)
            {
                for (int i = 0; i < mainMenu.Items.Count; i++)
                {
                    mainMenu.Items[i].Image.Update(gameTime);
                    float FirstItem = mainMenu.Items[0].Image.Alpha;
                    float LastItem = mainMenu.Items[mainMenu.Items.Count - 1].Image.Alpha;
                    if (FirstItem ==0.0f && LastItem==0.0f)
                    {
                        mainMenu.ID = mainMenu.Items[mainMenu.Itemnummer].LinkID;
                    }
                    else if (FirstItem == 1.0f && LastItem == 1.0f)
                    {
                        isTransitioning = false;
                        foreach (MenuItem item in mainMenu.Items)
                        {
                            item.Image.RestoreEffects();
                        }
                    }
                }
            }
        }
        public MenuManager()
        {
            mainMenu = new MainMenu();
            mainMenu.MenuChanging += MainMenu_MenuChanging;
        }

        private void MainMenu_MenuChanging(object sender, EventArgs e)
        {
            XmlManager<MainMenu> xmlManager = new XmlManager<MainMenu>();
            mainMenu.UnloadContent();
            mainMenu = xmlManager.Load(mainMenu.ID);
            mainMenu.LoadContent();
            mainMenu.MenuChanging += MainMenu_MenuChanging;
            mainMenu.Transitioning(0.0f);

            foreach (MenuItem item in mainMenu.Items)
            {
                item.Image.SaveEffects();
                item.Image.ActivateEffect("Fadeefect");
            }
        }
        public void LoadContent(string MenuPath)
        {
            if (MenuPath != String.Empty)
            {
                mainMenu.ID = MenuPath;
            }
        }
        public void UnloadContent()
        {
            mainMenu.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            if (!isTransitioning)
            {
                mainMenu.Update(gameTime);
            }
            if (KeyboardClass.Instance.KeyPressed(Keys.Enter) && !isTransitioning )
            {
                isTransitioning = true;
                if (mainMenu.Items[mainMenu.Itemnummer].LinkType =="Screen")
                {
                    ScreenManager.Instance.ChangeScreens(mainMenu.Items[mainMenu.Itemnummer].LinkID);
                }
                else
                {
                    isTransitioning = true;
                    mainMenu.Transitioning(1.0f);
                    foreach (MenuItem item in mainMenu.Items)
                    {
                        item.Image.SaveEffects();
                        item.Image.ActivateEffect("Fadeefect");
                    }
                }
            }
            Transitioning(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mainMenu.Draw(spriteBatch);
        }
    }
}
