using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandTask
{
    public class ClickManager : MonoBehaviour
    {
        private readonly ListLimit<Action> history = new(8);
        private readonly ListLimit<Func<Action>> schedule = new(5);

        public void Execute(Click command, Vector3 clickPosition)
        {
            history.Push(command.Execute(clickPosition));
        }

        public void Undo()
        {
            if (!history.TryPop(out Action action)) return;
            action.Invoke();
        }

        public void Schedule(Click command, Vector3 clickPosition)
        {
            schedule.Push(() => command.Execute(clickPosition));
        }

        public void ExecuteSchedule()
        {
            foreach (var executeDelegate in schedule.list)
            {
                history.list.Add(executeDelegate.Invoke());
            }
            schedule.list.Clear();
        }
    }
}
