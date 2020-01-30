using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Game9
{
    public class Image:IAssemble
    {
        public float Alpha;
        public string Text, FontName, Path;
        public Vector2 Position, Scale;
        ContentManager content;
        public Rectangle SourceRect;
        [XmlIgnore]
        public Texture2D Texture;
        Vector2 origin;

        public bool isActive;
        
        RenderTarget2D renderTarget;
        SpriteFont font;
       
        public string Effects;
        Dictionary<string, ImageEffect> effectlist;
        public Fade Fadeeffect;
        void SetEffect<T>(ref T effect)
        {
            if (effect==null)
            {
                effect = (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                (effect as ImageEffect).isActive = true;
                var obj = this;
                (effect as ImageEffect).LoadContent(ref obj);
            }
            effectlist.Add(effect.GetType().ToString().Replace("Game9.", ""),(effect as ImageEffect));
        }
        public void ActivateEffect(string effect)
        {
            if (effectlist.ContainsKey(effect))
            {
                effectlist[effect].isActive = true;
                var obj = this;
                effectlist[effect].LoadContent(ref obj);
            }
        }
        public void DeactivateEffect(string effect)
        {
            if (effectlist.ContainsKey(effect))
            {
                effectlist[effect].isActive = false;
                
                effectlist[effect].UnloadContent();
            }

        }
        public void SaveEffects()
        {
            Effects = String.Empty;
            foreach (var effect in effectlist)
            {
                if (effect.Value.isActive)
                {
                    Effects += effect.Key +":";
                }
            }
            if (Effects != String.Empty)
            {
                Effects.Remove(Effects.Length - 1);
            }
            
        }
        public void RestoreEffects()
        {
            foreach (var effect in effectlist)
            {
                DeactivateEffect(effect.Key);
            }
            string[] seperate = Effects.Split(':');
            foreach (string p in seperate)
            {
                ActivateEffect(p);
            }
        }
  
        public Image()
        {
            Path = Text = Effects = string.Empty;
            FontName = "Arial";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
            effectlist = new Dictionary<string, ImageEffect>();
        }
        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "content");
            if (Path != string.Empty)
            {
                Texture = content.Load<Texture2D>(Path);
            }
            font = content.Load<SpriteFont>(FontName);
            Vector2 dimensions = Vector2.Zero;

            if (Texture != null)
            {
                dimensions.X += Texture.Width;
            }
            dimensions.X += font.MeasureString(Text).X;
            if (Texture !=null)
            {
                dimensions.Y = Math.Max(Texture.Height, font.MeasureString(Text).Y);
            }
            else
            {
                dimensions.Y = font.MeasureString(Text).Y;
            }
            if (SourceRect == Rectangle.Empty)
            {
                SourceRect = new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y);
            }
            renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)dimensions.X, (int)dimensions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (Texture != null)
            {
                ScreenManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
            }
            ScreenManager.Instance.SpriteBatch.DrawString(font, Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();

            Texture = renderTarget;
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
            SetEffect<Fade>(ref Fadeeffect);
            //SetEffect<Hero_Animeren>(ref Hero_Animeren);
            if (Effects != string.Empty)
            {
                string[] split = Effects.Split(':');
                foreach (string item in split)
                {
                    ActivateEffect(item);
                }
            }
        }
        public  void UnloadContent()
        {
            content.Unload();
            foreach (var effect in effectlist)
            {
                DeactivateEffect(effect.Key);
            }
        }
        public  void Update(GameTime gameTime)
        {
            foreach (var effect in effectlist)
            {
                if (effect.Value.isActive)
                {
                    effect.Value.Update(gameTime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(SourceRect.Width / 2, SourceRect.Height / 2);
            spriteBatch.Draw(Texture,Position+origin, SourceRect,Color.White * Alpha,0.0f,origin,Scale,SpriteEffects.None,0.0f);
        }
    }
}
