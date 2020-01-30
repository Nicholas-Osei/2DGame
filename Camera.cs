using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game9;

namespace Game9
{
    public class Camera
    {
        Vector2 position;
        Matrix viewMatrix;
        public Matrix ViewMatrix
        {
            get
            {
                return viewMatrix;
            }
        }

        private static Camera instance;

        public static Camera Instance
        {
            get
            {
               if (instance==null)
                {
                    instance = new Camera();
                }
                return instance;
            }
        }
        public void SetFocalPoint(Vector2 focalPosition)
        {
            position = new Vector2(focalPosition.X - ScreenManager.Instance.Dimension.X / 2, focalPosition.Y - ScreenManager.Instance.Dimension.Y / 2);
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X+ScreenManager.Instance.Dimension.X >=5400)
            {
                position.X = 5400 - ScreenManager.Instance.Dimension.X;
            }
        }
        public void Update()
        {
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
