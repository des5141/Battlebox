using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleboxServer
{
    class LinkedQueue<T>
    {
        public int Count
        {
            get => _items.Count;
        }

        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Dequeue()
        {
            if (_items.First == null)
                throw new InvalidOperationException("...");

            var item = _items.First.Value;
            _items.RemoveFirst();

            return item;
        }

        public T Peek()
        {
            if (_items.First == null)
                throw new InvalidOperationException("...");

            var item = _items.First.Value;

            return item;
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Remove(_items.Skip(index).First());
        }

        private LinkedList<T> _items = new LinkedList<T>();
    }
}