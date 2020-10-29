using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlazorGame.Framework
{
    public class GameComponentCollection : Collection<IGameComponent>, IList<IGameComponent>, ICollection<IGameComponent>, IList, ICollection, IReadOnlyList<IGameComponent>, IReadOnlyCollection<IGameComponent>, IEnumerable<IGameComponent>, IEnumerable
    {
        public event EventHandler<GameComponentCollectionEventArgs> ComponentAdded;
        public event EventHandler<GameComponentCollectionEventArgs> ComponentRemoved;

        protected override void ClearItems()
        {

        }

        protected override void InsertItem(int index, IGameComponent item)
        {

        }

        protected override void RemoveItem(int index)
        {

        }

        protected override void SetItem(int index, IGameComponent item)
        {

        }
    }
}
