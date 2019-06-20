using UnityEngine;

namespace Roguelike.Rooms
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private TeleportPoint[] teleportPoints = new TeleportPoint[0];

        public TeleportPoint[] TeleportPoints { get { return teleportPoints; } }
    }
}
