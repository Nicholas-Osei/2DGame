using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    public abstract class Remote
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Space { get; set; }
        public bool D { get; set; }
        public bool Enter { get; set; }
        public abstract void Update();
    }

    public class JoyStick : Remote
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class KeyBoard : Remote
    {
        public Keys Leftk { get; set; }
        public Keys Rightk { get; set; }
        public Keys Upk { get; set; }
        public Keys Downk { get; set; }
        public Keys Spacek { get; set; }
        public Keys dk{ get; set; }
        public Keys Enterk { get; set; }

        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Leftk))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Leftk))
            {
                left = false;
            }
            if (stateKey.IsKeyDown(Rightk))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Rightk))
            {
                right = false;
            }
            if (stateKey.IsKeyDown(Upk))
            {
                Up = true;
            }
            if (stateKey.IsKeyUp(Upk))
            {
                Up = false;
            }
            if (stateKey.IsKeyDown(Downk))
            {
                Down = true;
            }
            if (stateKey.IsKeyUp(Downk))
            {
                Down = false;
            }
            if (stateKey.IsKeyDown(Spacek))
            {
                Space = true;
            }
            if (stateKey.IsKeyUp(Spacek))
            {
                Space = false;
            }
            if (stateKey.IsKeyDown(dk))
            {
                 D= true;
            }
            if (stateKey.IsKeyUp(dk))
            {
                D = false;
            }
            if (stateKey.IsKeyDown(Enterk))
            {
                Enter = true;
            }
            if (stateKey.IsKeyUp(Enterk))
            {
                Enter = false;
            }



        }
    }
}
