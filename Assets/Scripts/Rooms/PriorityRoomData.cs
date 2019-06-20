using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Rooms
{
    [System.Serializable]
    public class PriorityRoomData
    {
        [SerializeField] [Range(0f, 1f)] private float chance = 1f;
        [SerializeField] private List<Room> rooms = new List<Room>();

        public Room RandomRoom => rooms[Random.Range(0, rooms.Count)];

        public bool Roll() => Random.Range(0f, 1f) <= chance;
    }
}