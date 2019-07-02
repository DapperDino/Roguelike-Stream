using Roguelike.Interactables;
using Roguelike.LevelGeneration;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Roguelike.Rooms
{
    public class Room : MonoBehaviour
    {
        [Required] [SerializeField] private RoomType roomType = null;
        [SerializeField] private TeleportPoint[] teleportPoints = new TeleportPoint[0];

        public event Action onRoomFirstEntered = delegate { };

        public RoomType RoomType => roomType;
        public TeleportPoint[] TeleportPoints => teleportPoints;
        public LevelSettings LevelSettings { get; private set; } = null;

        private bool hasEntered = false;

        public void Initialise(LevelSettings levelSettings) => LevelSettings = levelSettings;

        public void Enter()
        {
            if (hasEntered) { return; }

            hasEntered = true;

            onRoomFirstEntered?.Invoke();
        }

        public void ToggleTeleportPoints(bool toggle)
        {
            for (int i = 0; i < teleportPoints.Length; i++)
            {
                teleportPoints[i].gameObject.SetActive(toggle);
            }
        }
    }
}
