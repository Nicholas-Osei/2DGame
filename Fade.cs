using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public class Fade:ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;
        public Fade()
        {
            FadeSpeed = 1;
            Increase = false;
        }
        public override void LoadContent(ref Image image)
        {
            base.LoadContent(ref image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (image.isActive)
            {
                if (!Increase)
                {
                    image.Alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                   image.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (image.Alpha <0.0f)
                {
                    Increase = true;
                    image.Alpha = 0.0f;
                }
                else if (image.Alpha>1.0f)
                {
                    Increase = false;
                    image.Alpha = 1.0f;
                }
            }
            else
            {
                image.Alpha = 1.0f;
            }
        }
    }
}
