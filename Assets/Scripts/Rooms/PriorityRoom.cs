using UnityEngine;

namespace Roguelike.Rooms
{
    public struct PriorityRoom
    {
        private Room[] rooms;
        public float MinRoomPercentageBeforeSpawn { get; }

        public PriorityRoom(Room[] rooms, float minRoomPercentageBeforeSpawn)
        {
            this.rooms = rooms;
            MinRoomPercentageBeforeSpawn = minRoomPercentageBeforeSpawn;
        }

        public Room Room => rooms[Random.Range(0, rooms.Length)];
    }
}