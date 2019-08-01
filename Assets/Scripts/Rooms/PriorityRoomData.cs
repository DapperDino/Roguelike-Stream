using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Rooms
{
    [System.Serializable]
    public class PriorityRoomData
    {
        [SerializeField] [Range(0f, 1f)] private float chance = 1f;
        [SerializeField] [Range(0f, 1f)] private float minRoomPercentageBeforeSpawn = 0;
        [SerializeField] [Min(1)] private int minQuantity = 1;
        [SerializeField] private int maxQuantity = 1;
        [SerializeField] private Room[] rooms = new Room[0];

        public List<PriorityRoom> RollRooms()
        {
            List<PriorityRoom> requiredRooms = new List<PriorityRoom>();

            if (Random.Range(0f, 1f) > chance) { return requiredRooms; }

            int quantity = Random.Range(minQuantity, maxQuantity + 1);

            for (int i = 0; i < quantity; i++)
            {
                requiredRooms.Add(
                    new PriorityRoom(
                        rooms,
                        minRoomPercentageBeforeSpawn));
            }

            return requiredRooms;
        }
    }
}