using Roguelike.Rooms;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class TeleportPoint : Interactable
    {
        [SerializeField] private Vector3 spawnOffset = new Vector3(0f, 0.5f, 0f);

        private TeleportPoint linkedPoint = null;
        private Room myRoom = null;

        public bool IsLinked => linkedPoint != null;
        public Room Room
        {
            get
            {
                if (myRoom == null)
                {
                    myRoom = GetComponentInParent<Room>();
                }
                return myRoom;
            }
        }

        public void Link(Room room)
        {
            foreach (TeleportPoint teleportPoint in room.TeleportPoints)
            {
                if (!teleportPoint.IsLinked)
                {
                    Link(teleportPoint);
                    teleportPoint.Link(this);
                    return;
                }
            }
        }

        public void Link(TeleportPoint teleportPoint)
        {
            linkedPoint = teleportPoint;

            SetRoomTypeColour();
        }

        private void SetRoomTypeColour() => GetComponent<Renderer>().material.color = linkedPoint.Room.RoomType.RoomTypeColour;

        protected override void Interact() => Player.MoveCharacterController(linkedPoint.transform.position + spawnOffset);

        private void OnDrawGizmos()
        {
            if (linkedPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, linkedPoint.transform.position);
            }
        }
    }
}
