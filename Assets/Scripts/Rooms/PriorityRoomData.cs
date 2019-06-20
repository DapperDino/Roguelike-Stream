using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Rooms
{
    [System.Serializable]
    public class PriorityRoomData
    {
        [SerializeField] [Range(0f, 1f)] private float chance = 1f;
        [SerializeField] [Range(0f, 1f)] private float minRoomPercentageBeforeSpawn = 0;
        [SerializeField] private List<Room> rooms = new List<Room>();

        public float MinRoomPercentageBeforeSpawn => minRoomPercentageBeforeSpawn;

        public Room RandomRoom => rooms[Random.Range(0, rooms.Count)];

        public bool Roll() => Random.Range(0f, 1f) <= chance;
    }
}