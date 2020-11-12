using Microsoft.JSInterop;
using System;

namespace BlazorGame.Framework.Media
{
    public static class MediaPlayer
    {
        internal static IJSRuntime JsRuntime { get; set; }
        public static bool GameHasControl { get; }
        public static bool IsMuted { get; set; }
        public static bool IsRepeating { get; set; }
        public static bool IsShuffled { get; set; }
        public static bool IsVisualizationEnabled { get; }
        public static TimeSpan PlayPosition { get; }
        public static MediaQueue Queue { get; }
        public static MediaState State { get; }
        public static float Volume { get; set; }

        public static event EventHandler<EventArgs> ActiveSongChanged;
        public static event EventHandler<EventArgs> MediaStateChanged;

        public static void MoveNext()
        {
            throw new NotImplementedException();
        }

        public static void Pause()
        {
            throw new NotImplementedException();
        }

        public static void Play(Song song)
        {            
            _ = JsRuntime.InvokeVoidAsync("BlazorGame.playAudio", song.Name, IsRepeating);
        }

        public static void Play(Song song, TimeSpan? startPosition)
        {
            throw new NotImplementedException();
        }

        public static void Play(SongCollection collection, int index = 0)
        {
            throw new NotImplementedException();
        }

        public static void Resume()
        {
            throw new NotImplementedException();
        }

        public static void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
