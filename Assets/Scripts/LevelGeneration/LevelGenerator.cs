using Roguelike.Rooms;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    public class LevelGenerator : SerializedMonoBehaviour
    {
        [SerializeField] private int minRooms, maxRooms;
        [SerializeField] private List<GameObject> spawnRooms = new List<GameObject>();
        [SerializeField] private List<GameObject> rooms = new List<GameObject>();
        [SerializeField] private List<List<GameObject>> requiredRooms = new List<List<GameObject>>();

        private List<Room> spawnedRooms = new List<Room>();
        private List<TeleportPoint> teleportPoints = new List<TeleportPoint>();

        private const int RoomOffset = 50;

        private void Start()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Room spawnRoom = Instantiate(spawnRooms[Random.Range(0, spawnRooms.Count)], transform).GetComponent<Room>();
            spawnedRooms.Add(spawnRoom);

            teleportPoints.AddRange(spawnRoom.TeleportPoints);

            SpawnAndLinkRooms();
        }

        private void SpawnAndLinkRooms()
        {
            int roomCount = 0;

            SpawnNormalRooms(ref roomCount);

            SpawnRequiredRooms();

            if (roomCount < minRooms || roomCount > maxRooms)
            {
                GenerateLevel();
            }
        }

        private void SpawnNormalRooms(ref int roomCount)
        {
            for (int i = 0; i < teleportPoints.Count; i++)
            {
                if (teleportPoints[i].IsLinked) { continue; }

                roomCount++;

                Room roomInstance = Instantiate(rooms[Random.Range(0, rooms.Count)], transform).GetComponent<Room>();
                spawnedRooms.Add(roomInstance);

                roomInstance.transform.Translate(new Vector3(roomCount * RoomOffset, 0f, 0f));

                teleportPoints.AddRange(roomInstance.TeleportPoints);

                teleportPoints[i].Link(roomInstance);
            }
        }

        private void SpawnRequiredRooms()
        {
            for (int i = 0; i < requiredRooms.Count; i++)
            {
                for (int j = 0; j < spawnedRooms.Count; j++)
                {
                    if (spawnedRooms[j].IsReplaceable)
                    {
                        Room spawnedRoom = Instantiate(
                            requiredRooms[i][Random.Range(0, requiredRooms[i].Count)],
                            transform).
                            GetComponent<Room>();

                        spawnedRoom.transform.position = spawnedRooms[j].transform.position;

                        Destroy(spawnedRooms[j].gameObject);

                        spawnedRooms[j] = spawnedRoom;

                        break;
                    }
                }
            }
        }
    }
}
