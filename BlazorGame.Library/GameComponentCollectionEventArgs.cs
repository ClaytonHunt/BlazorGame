using System;

namespace BlazorGame.Framework
{
    public class GameComponentCollectionEventArgs : EventArgs
    {
        public IGameComponent GameComponent { get; }

        public GameComponentCollectionEventArgs(IGameComponent gameComponent)
        {
            GameComponent = gameComponent;
        }
    }
}
