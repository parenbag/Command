using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommandTask
{
    public class ListLimit<T>
    {
        public readonly List<T> list = new();

        public int limit;

        public ListLimit(int limit)
        {
            this.limit = limit;
        }

        public void Push(T action)
        {
            list.Add(action);
            if (list.Count > limit) list.RemoveAt(0);
        }

        public T Pop()
        {
            var action = list.ElementAt(list.Count - 1);
            list.RemoveAt(list.Count - 1);
            return action;
        }

        public bool TryPop(out T action)
        {
            action = default;
            if (list.Count == 0) return false;
            action = Pop();
            return true;
        }
    }
}
