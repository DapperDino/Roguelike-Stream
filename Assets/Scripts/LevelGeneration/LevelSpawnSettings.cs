using Roguelike.Rooms;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    [CreateAssetMenu(fileName = "New Level Spawn Settings", menuName = "Level Generation/Level Spawn Settings")]
    public class LevelSpawnSettings : ScriptableObject
    {
        [SerializeField] [MinValue(0)] private int minRoomCount = 15;
        [SerializeField] private int maxRoomCount = 20;

        [Header("Rooms")]
        [SerializeField] private List<Room> spawnRooms = new List<Room>();
        [SerializeField] private List<Room> multiLinkRooms = new List<Room>();
        [SerializeField] private List<Room> deadEndRooms = new List<Room>();
        [SerializeField] private List<PriorityRoomData> priorityRooms = new List<PriorityRoomData>();

        public int RoomCount
        {
            get
            {
                if (minRoomCount > maxRoomCount)
                {
                    Debug.LogError("Incorrect Room Count In Level Spawn Settings");
                    return 0;
                }

                return Random.Range(minRoomCount, maxRoomCount + 1);
            }
        }
        public Room RandomSpawnRoom => spawnRooms[Random.Range(0, spawnRooms.Count)];
        public Room RandomMultiLinkRoom => multiLinkRooms[Random.Range(0, multiLinkRooms.Count)];
        public Room RandomDeadEndRoom => deadEndRooms[Random.Range(0, deadEndRooms.Count)];
        public List<Room> RequiredRooms
        {
            get
            {
                List<Room> rooms = new List<Room>();

                foreach (PriorityRoomData priorityRoom in priorityRooms)
                {
                    if (priorityRoom.Roll())
                    {
                        rooms.Add(priorityRoom.RandomRoom);
                    }
                }

                return rooms;
            }
        }
    }
}
