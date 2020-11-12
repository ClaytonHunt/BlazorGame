using System;

namespace BlazorGame.Framework.Media
{
    public class MediaQueue
    {
        public Song ActiveSong { get; }
        public int ActiveSongIndex { get; set; }
        public Song this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public MediaQueue()
        {
            throw new NotImplementedException();
        }
    }
}
