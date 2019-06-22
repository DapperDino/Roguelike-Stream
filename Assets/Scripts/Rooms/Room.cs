using Roguelike.LevelGeneration;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Rooms
{
    public class Room : MonoBehaviour
    {
        [Required] [SerializeField] private RoomType roomType = null;
        [SerializeField] private TeleportPoint[] teleportPoints = new TeleportPoint[0];

        public RoomType RoomType => roomType;
        public TeleportPoint[] TeleportPoints => teleportPoints;
        public LevelSettings LevelSettings { get; private set; } = null;

        public void Initialise(LevelSettings levelSettings) => LevelSettings = levelSettings;
    }
}
