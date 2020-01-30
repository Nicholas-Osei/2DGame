using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game9
{
    public class Soldier:IEntity
    {

        public Texture2D hero,hero2,hero3;
        public static Vector2 position, velocity;
        Animation animationLeft, animationRight, currentAnimation;
        public  static bool jumped;
        public float Addup = 0;
        public Rectangle CollisionRectangle;
        GamePlay play = new GamePlay();
        public int waarde=0;
        public Soldier()
        {}
        public Soldier(Texture2D _hero,Texture2D _heroLeft, Vector2 _position)
        {
            Init(_position);
            hero = _hero;
            hero2 = _heroLeft;
            hero3 = hero;
            position = _position;
            CreateAnimationRight();
            CreateAnimationLeft();
            jumped = true;
        }

        private void Init(Vector2 _position)
        {
            position = _position;
            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 161, 220); //161 230
        }
        public void CreateAnimationLeft()
        {
            animationLeft = new Animation();
            animationLeft.AddFrames(new Rectangle(355, 230, 161, 230));
            animationLeft.AddFrames(new Rectangle(179, 230, 161, 230));
            animationLeft.AddFrames(new Rectangle(0, 230, 161, 230));
            animationLeft.AddFrames(new Rectangle(355, 0, 161, 230));
            animationLeft.AddFrames(new Rectangle(179, 0, 161, 230));
            animationLeft.AddFrames(new Rectangle(0, 0, 161, 230));
            currentAnimation = animationLeft;
        }
        public  void CreateAnimationRight()
        {
            animationRight = new Animation();
            animationRight.AddFrames(new Rectangle(0, 0, 161, 230));
            animationRight.AddFrames(new Rectangle(162, 0, 161, 230));
            animationRight.AddFrames(new Rectangle(340, 0, 161, 230));
            animationRight.AddFrames(new Rectangle(0, 230, 161, 230));
            animationRight.AddFrames(new Rectangle(162, 230, 161, 230));
            animationRight.AddFrames(new Rectangle(340, 230, 161, 230));
            currentAnimation = animationRight;
        }
        public  void Draw(SpriteBatch sprite)
        {
            sprite.Draw(hero3, position, currentAnimation.current.Source, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            KeyBoardInputs(gameTime);
            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
            if (jumped == true)
            {
                velocity.Y += 0.15f * 1;
                position = Vector2.Add(position, velocity);
            }
            CollisionRectangle.X = (int)position.X;
            CollisionRectangle.Y = (int)position.Y;
            Camera.Instance.SetFocalPoint(new Vector2(position.X, ScreenManager.Instance.Dimension.Y / 2));
        }
        private void KeyBoardInputs(GameTime gameTime)
        {
            if (KeyboardClass.Instance.KeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;
                position = Vector2.Add(position, velocity);
                currentAnimation = animationLeft;
                currentAnimation.Animate(gameTime);
                hero3 = hero2;
                Limit_Timer.counter = 0;
            }
            if (KeyboardClass.Instance.KeyReleased(Keys.Right) || KeyboardClass.Instance.KeyReleased(Keys.Left)) 
            {
                jumped = true;
            }
            if (KeyboardClass.Instance.KeyDown(Keys.Right))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 5 ;
                waarde++;
                position = Vector2.Add(position, velocity);
                hero3 = hero;
                Limit_Timer.counter = 0;
                Console.WriteLine($"Counter bij soldier: {Limit_Timer.counter}");
                currentAnimation = animationRight;
                currentAnimation.Animate(gameTime);
            }
          
            if (KeyboardClass.Instance.KeyDown(Keys.Space) && jumped == false)
            {
                velocity.Y = -11f;
                jumped = true;
            }
            else if (KeyboardClass.Instance.KeyDown(Keys.V) && jumped == false)
            {
                velocity.Y = -15f;
                jumped = true;
            }
        }
        public void Collisions(Rectangle rect, int xoffset, int yofsset)
        {
            if (CollisionRectangle.IsOnTopOf(rect))
            {
                CollisionRectangle.Y = rect.Y - CollisionRectangle.Height;
                velocity.Y = 0f;
                jumped = false;
            }
            if (CollisionRectangle.IsOnLeft(rect))
            {
                position.X = rect.X - CollisionRectangle.Width - 10;
            }
            if (CollisionRectangle.IsOnRight(rect))
            {
                position.X = rect.X + CollisionRectangle.Width - 50;
            }
            if (CollisionRectangle.IsOnBottom(rect))
            {
                velocity.Y = 1f;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X > xoffset - CollisionRectangle.Width)
            {
                position.X = xoffset - CollisionRectangle.Width;
            }
            if (position.Y < 0)
            {
                velocity.Y = 1f;
            }
            if (position.Y > yofsset - CollisionRectangle.Height) //fall
            {
                position.Y = yofsset - CollisionRectangle.Height + 300f;
                velocity.X = 0;
                GamePlay.Dead = true;
            }
        }
    }
}