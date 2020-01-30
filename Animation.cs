using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public class Animation
    {
        private List<SourceRectangle> frames;
        public SourceRectangle current;
        public double time;
        int numnerframe = 0;
        public bool IsRemoved = false;
        public Animation()
        {
            frames = new List<SourceRectangle>();
            time = 0;
        }
        public void AddFrames(Rectangle rectangle)
        {
            SourceRectangle frameMove = new SourceRectangle
            {
                Source = rectangle
            };
            frames.Add(frameMove);
            current = frames[0];
        }
        public virtual void Animate(GameTime game)
        {
            time += current.Source.Width * game.ElapsedGameTime.Milliseconds/100;
            if (time >= current.Source.Width)
            {
                numnerframe++;
                if (numnerframe >= frames.Count)
                {
                    numnerframe = 0;
                }
                current = frames[numnerframe];
                time = 0;
            }
        }
    }
}
