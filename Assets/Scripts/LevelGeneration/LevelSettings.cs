using Roguelike.Combat.Enemies;
using Roguelike.Items;
using Roguelike.Rooms;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    [CreateAssetMenu(fileName = "New Level Settings", menuName = "Level Generation/Level Settings")]
    public class LevelSettings : SerializedScriptableObject
    {
        [SerializeField] [MinValue(0)] private int minRoomCount = 15;
        [SerializeField] private int maxRoomCount = 17;
        [SerializeField] [MinValue(0)] private int minEnemyCount = 2;
        [SerializeField] private int maxEnemyCount = 6;

        [Header("Rooms")]
        [SerializeField] private List<Room> spawnRooms = new List<Room>();
        [SerializeField] private List<Room> multiLinkRooms = new List<Room>();
        [SerializeField] private List<Room> deadEndRooms = new List<Room>();
        [SerializeField] private List<PriorityRoomData> priorityRooms = new List<PriorityRoomData>();

        [Header("Enemies")]
        [SerializeField] private ChancePicker<EnemyLogic> enemyPicker = null;

        [Header("Qualities")]
        [SerializeField] private ChancePicker<Quality> qualityHandler = null;

        public int MinRoomCount => minRoomCount;
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
        public int EnemyCount
        {
            get
            {
                if (minEnemyCount > maxEnemyCount)
                {
                    Debug.LogError("Incorrect Enemy Count In Level Spawn Settings");
                    return 0;
                }

                return Random.Range(minEnemyCount, maxEnemyCount + 1);
            }
        }
        public Room RandomSpawnRoom => spawnRooms[Random.Range(0, spawnRooms.Count)];
        public Room RandomMultiLinkRoom => multiLinkRooms[Random.Range(0, multiLinkRooms.Count)];
        public Room RandomDeadEndRoom => deadEndRooms[Random.Range(0, deadEndRooms.Count)];
        public List<PriorityRoom> RequiredRooms
        {
            get
            {
                List<PriorityRoom> requiredRooms = new List<PriorityRoom>();

                foreach (PriorityRoomData priorityRoomData in priorityRooms)
                {
                    requiredRooms.AddRange(priorityRoomData.RollRooms());
                }

                return requiredRooms;
            }
        }
        public ChancePicker<EnemyLogic> EnemyPicker => enemyPicker;
        public ChancePicker<Quality> QualityHandler => qualityHandler;
    }
}
