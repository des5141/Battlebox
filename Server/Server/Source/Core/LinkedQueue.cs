using System;
using System.Collections.Generic;
using System.Linq;
using Server.Source.User;

namespace Server.Source.Core
{
    public class LinkedQueue<T>
    {
        public int Count => Items.Count;

        public void Enqueue(T item)
        {
            Items.AddLast(item);
        }

        public T Dequeue()
        {
            if (Items.First == null)
                throw new InvalidOperationException("...");

            var item = Items.First.Value;
            Items.RemoveFirst();

            return item;
        }

        public T Peek()
        {
            if (Items.First == null)
                throw new InvalidOperationException("...");

            var item = Items.First.Value;

            return item;
        }

        public T PeekAt(int index)
        {
            return Items.ElementAt(index);
        }

        public void Remove(T item)
        {
            Items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Remove(Items.Skip(index).First());
        }

        public readonly LinkedList<T> Items = new LinkedList<T>();
    }
}
