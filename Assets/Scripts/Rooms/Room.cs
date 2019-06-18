using UnityEngine;

namespace Roguelike.Rooms
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private bool isReplaceable = true;
        [SerializeField] private TeleportPoint[] teleportPoints = new TeleportPoint[0];

        public TeleportPoint[] TeleportPoints { get { return teleportPoints; } }
        public bool IsReplaceable => teleportPoints.Length == 1 && isReplaceable;
    }
}
