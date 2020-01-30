using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game9
{
    public class Enemy:IEntity
    {
        public Enemy()
        { }
        readonly Texture2D man;
        public Vector2 position, velocity;
        Animation animationLeft, animationRight, currentAnimation;
        public Rectangle ColliEnemy;
        public bool jumped;
        int level = 1;
        public int guess=1;
        public Enemy(Texture2D texture, Vector2 vector2)
        {
            man = texture;
            position = vector2;
            ColliEnemy = new Rectangle((int)position.X, (int)position.Y, 125, 250);
            CreateAnimationRight();
            CreateAnimationLeft();
            jumped = true;
        }
        public void Draw(SpriteBatch sprite)
        {
          sprite.Draw(man, position,currentAnimation.current.Source, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 18;
            position = Vector2.Add(position, velocity);
            currentAnimation = animationLeft;
            currentAnimation.Animate(gameTime);
            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
            if (jumped == true)
            {
                velocity.Y += 0.15f * 1;
                position = Vector2.Add(position, velocity);
            }
            ColliEnemy.X = (int)position.X;
            ColliEnemy.Y = (int)position.Y;
        }
        public void CollisionEnemyOntiles(Rectangle rect, int xoffset, int yofsset,GameTime gameTime)
        {
            if (ColliEnemy.IsOnLeft(rect))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 18;
                position.X = rect.X - ColliEnemy.Width - 10;
                velocity.Y = -5f;
                position = Vector2.Add(position, velocity);
                jumped = true;
            }
            else if (ColliEnemy.IsOnTopOf(rect))
            {
                ColliEnemy.Y = rect.Y - ColliEnemy.Height ;
                velocity.Y = 0f;
                jumped = true;
            }
            else if (ColliEnemy.IsOnRight(rect))
            {
                position.X = rect.X + ColliEnemy.Width - 50;
                velocity.Y = -15f;
                position = Vector2.Add(position, velocity);
                jumped = true;
            }
            if (position.Y > yofsset - ColliEnemy.Height) //fall
            {
                position.Y = yofsset - ColliEnemy.Height + 300f;
                velocity.X = 0;
            }
        }
        public void CreateAnimationRight()
        {
            animationRight = new Animation();
            animationRight.AddFrames(new Rectangle(512, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(256, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(128, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(0, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(512, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(256, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(128, 256, 128, 128));
            animationRight.AddFrames(new Rectangle(0, 256, 128, 128));
            currentAnimation = animationRight;

        }

        public void CreateAnimationLeft()
        {
            animationLeft = new Animation();
            if (GamePlay.levelCounter == 1)
            {
                animationLeft.AddFrames(new Rectangle(420, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(380, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(260, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(130, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(0, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(420, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(380, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(260, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(130, 460, 130, 230));
                animationLeft.AddFrames(new Rectangle(0, 460, 130, 230));
            }
            if (GamePlay.levelCounter == 2)
            {
                animationLeft.AddFrames(new Rectangle(420, 690, 130, 230));
                animationLeft.AddFrames(new Rectangle(380, 690, 130, 230));
                animationLeft.AddFrames(new Rectangle(260, 690, 130, 230));
                animationLeft.AddFrames(new Rectangle(130, 230, 130, 230));
                animationLeft.AddFrames(new Rectangle(0, 230, 130, 230));
                animationLeft.AddFrames(new Rectangle(420, 690, 130, 230));
                animationLeft.AddFrames(new Rectangle(380, 690, 130, 230));
                animationLeft.AddFrames(new Rectangle(260, 690, 130, 230));
                animationLeft.AddFrames(new Rectangle(130, 230, 130, 230));
                animationLeft.AddFrames(new Rectangle(0, 230, 130, 230));
            }
            if (GamePlay.levelCounter == 3)
            {
                animationLeft.AddFrames(new Rectangle(420, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(380, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(260, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(130, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(0, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(420, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(380, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(260, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(130, 0, 130, 230));
                animationLeft.AddFrames(new Rectangle(0, 0, 130, 230));
            }
            currentAnimation = animationLeft;
        }
        public  void AddEnemies(List<Enemy>Enemies, Texture2D _enemy,int _level)
        {
            level = _level;
            if (_level == 1)
            {
                for (int i = 1; i < 15; i++)
                {
                   Enemies.Add(new Enemy(_enemy, new Vector2(i* 700, i* -300)));
                }
            }
            if (_level == 2)
            {
                for (int i = 1; i < 25; i++)
                {
                    Enemies.Add(new Enemy(_enemy, new Vector2(i * 700, i * -400)));
                }
            }
            if (_level == 3)
            {
                for (int i = 1; i < 60; i++)
                {
                    Enemies.Add(new Enemy(_enemy, new Vector2(i * 700, i * -100)));
                }
            }
        }
    }
}
