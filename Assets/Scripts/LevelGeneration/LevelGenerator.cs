using Roguelike.Rooms;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.LevelGeneration
{
    public class LevelGenerator : SerializedMonoBehaviour
    {
        [Required] [SerializeField] private LevelSpawnSettings levelSpawnSettings = null;

        private const int RoomOffset = 75;

        private void Start() => GenerateLevel();

        [Button]
        [DisableInEditorMode]
        private void GenerateLevel()
        {
            //Initialise Variables.
            int roomCount = 1;
            int desiredRoomCount = levelSpawnSettings.RoomCount;
            List<TeleportPoint> teleportPoints = new List<TeleportPoint>();

            //Clear any previous generation.
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }       

            //Initialise with a random spawn room.
            Room spawnRoom = Instantiate(levelSpawnSettings.RandomSpawnRoom, transform);
            teleportPoints.AddRange(spawnRoom.TeleportPoints);         

            //TODO Finish Generation
            while (teleportPoints.Count > 0 && roomCount < desiredRoomCount)
            {
                //Pick a random teleport point.
                TeleportPoint teleportPoint = teleportPoints[Random.Range(0, teleportPoints.Count)];

                //Remove it from the list if it is already linked.
                if (teleportPoint.IsLinked)
                {
                    teleportPoints.Remove(teleportPoint);
                    continue;
                }

                //Spawn in a new random room.
                Room roomInstance = Instantiate(levelSpawnSettings.RandomMultiLinkRoom, transform);
                roomInstance.transform.Translate(new Vector3(roomCount * RoomOffset, 0f, 0f));
                roomCount++;

                //Add the new teleport points to the list.
                teleportPoints.AddRange(roomInstance.TeleportPoints);

                //Link the randomly selected teleport point to the new room.
                teleportPoint.Link(roomInstance);
            }
        }
    }
}
