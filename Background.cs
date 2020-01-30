using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    class Background
    {
        public List<Texture2D> background;
        public void Load(List<Texture2D> _background)
        {
            background = _background;
        }
        public void Draw (SpriteBatch spriteBatch)
        {
            switch (GamePlay.levelCounter)
            {
                case 1:
                    spriteBatch.Draw(background[0], new Rectangle(0, 0, (int)ScreenManager.Instance.Dimension.X + (int)Soldier.position.X, (int)ScreenManager.Instance.Dimension.Y), Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(background[1], new Rectangle(0, 0, (int)ScreenManager.Instance.Dimension.X + (int)Soldier.position.X, (int)ScreenManager.Instance.Dimension.Y), Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(background[2], new Rectangle(0, 0, (int)ScreenManager.Instance.Dimension.X + (int)Soldier.position.X, (int)ScreenManager.Instance.Dimension.Y), Color.White);
                    break;
            }
        }
    }
}
