using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game9
{
    class GameSongs 
    {
        private readonly Song zombie_song;
        SoundEffect gunEffect;
        public GameSongs(SoundEffect _gunEffect, Song _zombie_song )
        {
            gunEffect = _gunEffect;
            zombie_song = _zombie_song;
        }
        public void LoadContent()
        {
            MediaPlayer.Play(zombie_song);
            MediaPlayer.IsRepeating = true;
        }
        public void SongPause()
        {
            MediaPlayer.Pause();
        }
        public void SongResume()
        {
            MediaPlayer.Resume();
        }

    }
}
