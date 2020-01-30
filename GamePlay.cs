using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game9
{
    public class GamePlay : GameScreen
    {

        public Texture2D man,manLeft, block,Enemy1,door,end,dead,bulletImage, PauseImage;
        List<Texture2D> background;
        Door Door;
        Soldier Soldier;
        Enemy enemy;
        public static SpriteFont font;
        Limit_Timer timer;
        List<Bullet> bullets = new List<Bullet>();
        List<Enemy> Enemies = new List<Enemy>();
        public  static bool Dead = false;
        private bool Ended = false;
        Map map;
        public static int levelCounter=2;
        Bullet kogel;
        Song zombie_Roar;
        SoundEffect soundEffect;
        Background backgroundClass;
        GameSongs gameSongs;
        public override void LoadContent()
        {
            base.LoadContent();
            backgroundClass = new Background();
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "content");
            man = content.Load<Texture2D>("Walk_soldier");
            manLeft = content.Load<Texture2D>("Walk_soldier_Left");
            Enemy1 = content.Load<Texture2D>("zombie_Left");
            zombie_Roar = content.Load<Song>("Zombie_sound");
            soundEffect = content.Load<SoundEffect>("380_gunshot");
            gameSongs = new GameSongs(soundEffect, zombie_Roar);
           
            background = new List<Texture2D>
            {
                content.Load<Texture2D>("background"),
                content.Load<Texture2D>("DeadWoods"),
                content.Load<Texture2D>("living_forest_")
            };
            backgroundClass.Load(background); 
            door = content.Load<Texture2D>("door");
            end = content.Load<Texture2D>("End");
            font = content.Load<SpriteFont>("Timer");
            dead = content.Load<Texture2D>("dead");
            bulletImage = content.Load<Texture2D>("bullet");
            PauseImage = content.Load<Texture2D>("PAUSE");
            enemy = new Enemy();
            timer = new Limit_Timer();
            timer.LoadContent(font);
            Soldier = new Soldier(man,manLeft, new Vector2(0, 0));
            kogel = new Bullet(bulletImage,new Vector2(0,0));
            Door = new Door(door);
            map = new Map();
            Tile.Content = content;
            map.Level1();
            levelCounter++;
            enemy.AddEnemies(Enemies, Enemy1, levelCounter);
            gameSongs.LoadContent();
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gametime)
        {
            if (!Unpause.pausing)
            {
                kogel.VelocityBullet = new Vector2(Soldier.velocity.X, Soldier.velocity.Y) * 1f + Soldier.velocity; //direction en kogels overal
                UpdateBullets();
                foreach (CollisionTiles tiles in map.CollisionTiles)
                {
                    Soldier.Collisions(tiles.Rectangle, map.Width, map.Height);
                    foreach (Enemy vijand in Enemies)
                    {
                        vijand.CollisionEnemyOntiles(tiles.Rectangle, map.Width, map.Height, gametime);
                    }
                }
                if (Soldier.CollisionRectangle.Intersects(Door.Colli) && levelCounter == 1)
                {
                    Door.vector = new Vector2(0, 800);
                    Door.Colli = new Rectangle(0, 800, 128, 96);
                    map = new Map();
                    map.Level2();
                    Soldier.position.X = 0;
                    Soldier.position.Y = 0;
                    levelCounter++;
                    enemy.AddEnemies(Enemies, Enemy1, levelCounter);
                }
                if (Soldier.CollisionRectangle.Intersects(Door.Colli) && levelCounter == 2)
                {
                    Door.vector = new Vector2(600, 200);
                    Door.Colli = new Rectangle(600, 200, 128, 96);
                    map = new Map();
                    map.Level3();
                    Soldier.velocity.Y = 0.4f;
                    Soldier.position.X = 0f;
                    Soldier.position.Y = 0f;
                    Soldier.position = Vector2.Add(Soldier.position, Soldier.velocity);
                    levelCounter++;
                    enemy.AddEnemies(Enemies, Enemy1, levelCounter);
                }
                if (KeyboardClass.Instance.KeyDown(Keys.C))
                {
                    map = new Map();
                    map.generator();
                }
                if (KeyboardClass.Instance.KeyDown(Keys.A))
                {
                    Shoot();
                }
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].ColliBullet.Intersects(Enemies[i].ColliEnemy))
                    {
                        Enemies[i].position.X = 100000000000;
                    }
                }
                
                map.KillerMap();
                Soldier.Update(gametime);
                //for (int i = 0; i < Enemies.Count; i++)
                //{
                //    if (Soldier.CollisionRectangle.Intersects(Enemies[i].ColliEnemy) || Limit_Timer.counter == 3)
                //    {
                //        Dead = true;
                //    }
                //}
                foreach (Enemy vijand in Enemies)
                {
                    vijand.Update(gametime);
                }
                foreach (Bullet item in bullets)
                {
                    item.Update(gametime);
                }
                timer.Timer(gametime);
                if (Dead || Ended )
                {
                    if (KeyboardClass.Instance.KeyPressed(Keys.Enter))
                    {
                        ScreenManager.Instance.ChangeScreens("TitleScreen");
                        Limit_Timer.timer = 0;
                        levelCounter = 0;   
                        enemy.AddEnemies(Enemies, Enemy1, levelCounter);
                        map.Level1();
                        MediaPlayer.Pause();
                        Dead = false;
                    }
                    base.LoadContent();
                }
                if (KeyboardClass.Instance.KeyPressed(Keys.P))
                {  
                    Unpause.pausing = !Unpause.pausing;
                    gameSongs.SongPause();
                }
            }
            if (KeyboardClass.Instance.KeyPressed(Keys.L))
            {
                Unpause.pausing = false;
                gameSongs.SongResume();
            }
            base.Update(gametime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            backgroundClass.Draw(spriteBatch);
            base.Draw(spriteBatch);
            timer.Draw(spriteBatch);
            foreach (Bullet item in bullets)
            {
               item.Draw(spriteBatch);
            }
            map.Draw(spriteBatch);
            Soldier.Draw(spriteBatch);
            foreach (Enemy vijand in Enemies)
            {
              vijand.Draw(spriteBatch);
            }
            Door.Draw(spriteBatch);
            if (Soldier.CollisionRectangle.Intersects(Door.Colli) && levelCounter == 3 )
            {
                spriteBatch.Draw(end, new Rectangle(0, 0, (int)ScreenManager.Instance.Dimension.X, (int)ScreenManager.Instance.Dimension.Y), Color.Wheat);
                Ended = true;
            }
            if (Dead)
            {
                Soldier.position.X = 0;
                 spriteBatch.Draw(dead, new Rectangle(0, 0, (int)ScreenManager.Instance.Dimension.X, (int)ScreenManager.Instance.Dimension.Y), Color.Wheat);
            }
            if (Unpause.pausing)
            {
                Unpause unpause = new Unpause();
                unpause.Draw(spriteBatch);
            }
        }
        public void Shoot()
        {
            soundEffect.Play();
            kogel.PositionBullet = Soldier.position + kogel.VelocityBullet * 25; // van waar de kogel vertrekt
            kogel.Zichtbaar = true;
            if (bullets.Count < 1)
            {
                for (int i = 0; i < Enemies.Count; i++)
                {
                    bullets.Add(kogel);
                }
            }
        }
        public void UpdateBullets()
        {
            foreach (Bullet item in bullets)
            {
                item.PositionBullet += item.VelocityBullet;
                if (Vector2.Distance(item.PositionBullet, Soldier.position) > 1000)
                {
                    item.Zichtbaar = false;
                }
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].Zichtbaar) //bullets wegdoen
                {
                    bullets.RemoveAt(i);
                    i--;//vermijd een infinte loop
                }
            }
        }
    }
}
