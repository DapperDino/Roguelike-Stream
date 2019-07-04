using Roguelike.Combat;
using Roguelike.Interactables;
using Roguelike.Rooms;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    public class LevelGenerator : SerializedMonoBehaviour
    {
        [Required] [SerializeField] private LevelSettings levelSettings = null;
        [SerializeField] private float requiredRoomChance = 0.15f;
        [SerializeField] private float deadEndPercentage = 0.5f;

        private Transform player = null;

        private const int RoomOffset = 75;

        private void Start() => GenerateLevel();

        public void GenerateLevel()
        {
            player = FindObjectOfType<PlayerDamageable>().transform;

            int roomCount = 1;
            int desiredRoomCount = levelSettings.RoomCount;
            List<TeleportPoint> teleportPoints = new List<TeleportPoint>();

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Room spawnRoom = SpawnRoom(levelSettings.RandomSpawnRoom);
            teleportPoints.AddRange(spawnRoom.TeleportPoints);

            List<PriorityRoom> requiredRooms = levelSettings.RequiredRooms;

            while ((teleportPoints.Count > 0 && roomCount < desiredRoomCount) || requiredRooms.Count > 0)
            {
                if (teleportPoints.Count == 0)
                {
                    GenerateLevel();
                    return;
                }

                TeleportPoint teleportPoint = teleportPoints[Random.Range(0, teleportPoints.Count)];

                if (teleportPoint.IsLinked)
                {
                    teleportPoints.Remove(teleportPoint);
                    continue;
                }

                Room roomInstance = null;

                if (requiredRooms.Count > 0)
                {
                    if (Random.Range(0f, 1f) <= requiredRoomChance || requiredRooms.Count == desiredRoomCount - roomCount)
                    {
                        PriorityRoom requiredRoom = requiredRooms[Random.Range(0, requiredRooms.Count)];

                        if (requiredRoom.MinRoomPercentageBeforeSpawn <= roomCount / desiredRoomCount)
                        {
                            Room room = requiredRoom.Room;
                            roomInstance = SpawnRoom(room);
                            requiredRooms.Remove(requiredRoom);
                        }
                    }
                }

                if (roomInstance == null)
                {
                    if (Random.Range(0f, 1f) <= deadEndPercentage)
                    {
                        roomInstance = SpawnRoom(levelSettings.RandomDeadEndRoom);
                    }
                    else
                    {
                        roomInstance = SpawnRoom(levelSettings.RandomMultiLinkRoom);
                    }
                }

                roomInstance.transform.Translate(new Vector3(roomCount * RoomOffset, 0f, 0f));
                roomCount++;

                teleportPoints.AddRange(roomInstance.TeleportPoints);

                teleportPoint.Link(roomInstance);
            }

            while (teleportPoints.Count > 0)
            {
                TeleportPoint teleportPoint = teleportPoints[Random.Range(0, teleportPoints.Count)];

                teleportPoints.Remove(teleportPoint);

                if (teleportPoint.IsLinked) { continue; }

                teleportPoint.Disabled = true;
            }

            if (roomCount < levelSettings.MinRoomCount)
            {
                GenerateLevel();
                return;
            }
        }

        private Room SpawnRoom(Room room)
        {
            Room roomInstance = Instantiate(room, transform);

            roomInstance.Initialise(player, levelSettings);

            return roomInstance;
        }
    }
}
