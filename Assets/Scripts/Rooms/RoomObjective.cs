using System;
using UnityEngine;

namespace Roguelike.Rooms
{
    public abstract class RoomObjective : MonoBehaviour
    {
        public Action onObjectiveCompleted = delegate { };

        public abstract bool IsComplete();
    }
}
