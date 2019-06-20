using Roguelike.Rooms;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    public class LevelGenerator : SerializedMonoBehaviour
    {
        [Required] [SerializeField] private LevelSpawnSettings levelSpawnSettings = null;
        [SerializeField] private float requiredRoomChance = 0.15f;
        [SerializeField] private float chanceOfEarlyDeadEnd = 0.6f;

        private const int RoomOffset = 75;

        private void Start() => GenerateLevel();

        [Button]
        [DisableInEditorMode]
        private void GenerateLevel()
        {
            int roomCount = 1;
            int desiredRoomCount = levelSpawnSettings.RoomCount;
            List<TeleportPoint> teleportPoints = new List<TeleportPoint>();

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Room spawnRoom = Instantiate(levelSpawnSettings.RandomSpawnRoom, transform);
            teleportPoints.AddRange(spawnRoom.TeleportPoints);

            List<PriorityRoomData> requiredRoomData = levelSpawnSettings.RequiredRooms;

            while ((teleportPoints.Count > 0 && roomCount < desiredRoomCount) || requiredRoomData.Count > 0)
            {
                if(teleportPoints.Count == 0)
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

                if (requiredRoomData.Count > 0)
                {
                    if (Random.Range(0f, 1f) <= requiredRoomChance || requiredRoomData.Count == desiredRoomCount - roomCount)
                    {
                        PriorityRoomData roomData = requiredRoomData[Random.Range(0, requiredRoomData.Count)];

                        if(roomData.MinRoomPercentageBeforeSpawn <= roomCount / desiredRoomCount)
                        {
                            Room requiredRoom = roomData.RandomRoom;
                            roomInstance = Instantiate(requiredRoom, transform);
                            requiredRoomData.Remove(roomData);
                        }
                    }
                }

                if (roomInstance == null)
                {
                    if (Random.Range(0f, 1f) <= chanceOfEarlyDeadEnd)
                    {
                        roomInstance = Instantiate(levelSpawnSettings.RandomDeadEndRoom, transform);
                    }
                    else
                    {
                        roomInstance = Instantiate(levelSpawnSettings.RandomMultiLinkRoom, transform);
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

                Room roomInstance = Instantiate(levelSpawnSettings.RandomDeadEndRoom, transform);
                roomInstance.transform.Translate(new Vector3(roomCount * RoomOffset, 0f, 0f));
                roomCount++;

                teleportPoint.Link(roomInstance);

                teleportPoints.Remove(teleportPoint);
            }

            if (roomCount < levelSpawnSettings.MinRoomCount)
            {
                GenerateLevel();
                return;
            }
        }
    }
}
