﻿using Roguelike.Interactables;
using Roguelike.Rooms;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [Required] [SerializeField] private LevelSettings levelSettings = null;
        [SerializeField] private float requiredRoomChance = 0.15f;

        private const int RoomOffset = 55;

        private void Start() => GenerateLevel();

        public void GenerateLevel()
        {
            int roomCount = 1;
            int desiredRoomCount = levelSettings.RoomCount;
            List<TeleportPoint> teleportPoints = new List<TeleportPoint>();
            List<Vector2Int> usedSpaces = new List<Vector2Int>();

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Room spawnRoom = SpawnRoom(levelSettings.RandomSpawnRoom);

            usedSpaces.Add(new Vector2Int(0, 0));

            teleportPoints.AddRange(spawnRoom.TeleportPoints);

            List<PriorityRoom> requiredRooms = levelSettings.RequiredRooms;

            while ((teleportPoints.Count > 0 && roomCount < desiredRoomCount) || requiredRooms.Count > 0)
            {
                if (teleportPoints.Count == 0)
                {
                    GenerateLevel();
                    return;
                }

                for (int i = teleportPoints.Count - 1; i >= 0; i--)
                {
                    if (teleportPoints[i].IsLinked)
                    {
                        teleportPoints.RemoveAt(i);
                    }
                }

                TeleportPoint teleportPoint = teleportPoints[Random.Range(0, teleportPoints.Count)];

                Vector2Int roomTranslateDirection = GetRoomTranslationDirection(teleportPoint);

                Vector2Int teleportPointRoomCoordinates = new Vector2Int(
                    (int)teleportPoint.Room.transform.position.x / RoomOffset,
                    (int)teleportPoint.Room.transform.position.z / RoomOffset);

                if (usedSpaces.Contains(teleportPointRoomCoordinates + roomTranslateDirection))
                {
                    teleportPoints.Remove(teleportPoint);

                    teleportPoint.IsDisabled = true;

                    continue;
                }

                Room roomInstance = null;
                Directions direction = teleportPoint.ExitDirection;

                if (teleportPoints.Count == 1)
                {
                    Room room = null;
                    TeleportPoint tp = null;

                    while (tp == null)
                    {
                        room = levelSettings.RandomMultiLinkRoom;
                        tp = room.GetOpposingPoint(teleportPoint);
                    }

                    roomInstance = SpawnRoom(room);
                }

                if (roomInstance == null)
                {
                    if (requiredRooms.Count > 0)
                    {
                        if (Random.Range(0f, 1f) <= requiredRoomChance || requiredRooms.Count >= desiredRoomCount - roomCount)
                        {
                            PriorityRoom requiredRoom = requiredRooms[Random.Range(0, requiredRooms.Count)];

                            if (requiredRoom.MinRoomPercentageBeforeSpawn <= (float)roomCount / desiredRoomCount)
                            {
                                Room room = null;
                                TeleportPoint tp = null;

                                while (tp == null)
                                {
                                    room = requiredRoom.Room;
                                    tp = room.GetOpposingPoint(teleportPoint);
                                }

                                roomInstance = SpawnRoom(room);
                                requiredRooms.Remove(requiredRoom);
                            }
                        }
                    }
                }

                if (roomInstance == null)
                {
                    if (Random.Range(0f, 1f) <= 0.5f)
                    {
                        Room room = null;
                        TeleportPoint tp = null;

                        while (tp == null)
                        {
                            room = levelSettings.RandomDeadEndRoom;
                            tp = room.GetOpposingPoint(teleportPoint);
                        }
                        roomInstance = SpawnRoom(room);
                    }
                    else
                    {
                        Room room = null;
                        TeleportPoint tp = null;

                        while (tp == null)
                        {
                            room = levelSettings.RandomMultiLinkRoom;
                            tp = room.GetOpposingPoint(teleportPoint);
                        }

                        roomInstance = SpawnRoom(room);
                    }
                }

                roomInstance.transform.position = new Vector3(
                    teleportPoint.Room.transform.position.x,
                    0f,
                    teleportPoint.Room.transform.position.z);

                roomInstance.transform.Translate(new Vector3(
                    roomTranslateDirection.x * RoomOffset,
                    0f,
                    roomTranslateDirection.y * RoomOffset));

                usedSpaces.Add(teleportPointRoomCoordinates += roomTranslateDirection);

                roomCount++;

                teleportPoints.AddRange(roomInstance.TeleportPoints);

                teleportPoint.Link(roomInstance);
            }

            while (teleportPoints.Count > 0)
            {
                TeleportPoint teleportPoint = teleportPoints[Random.Range(0, teleportPoints.Count)];

                teleportPoints.Remove(teleportPoint);

                if (teleportPoint.IsLinked) { continue; }

                teleportPoint.IsDisabled = true;
            }
        }

        private Vector2Int GetRoomTranslationDirection(TeleportPoint teleportPoint)
        {
            Vector2Int roomTranslateDirection = new Vector2Int();

            switch (teleportPoint.ExitDirection)
            {
                case Directions.Up:
                    roomTranslateDirection.y = 1;
                    break;

                case Directions.Right:
                    roomTranslateDirection.x = 1;
                    break;

                case Directions.Down:
                    roomTranslateDirection.y = -1;
                    break;

                case Directions.Left:
                    roomTranslateDirection.x = -1;
                    break;
            }

            return roomTranslateDirection;
        }

        private Room SpawnRoom(Room room)
        {
            Room roomInstance = Instantiate(room, transform);

            roomInstance.Initialise(levelSettings);

            return roomInstance;
        }
    }
}
