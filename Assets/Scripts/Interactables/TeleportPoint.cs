using Roguelike.Rooms;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class TeleportPoint : Interactable
    {
        [SerializeField] private Directions exitDirection = Directions.None;

        private TeleportPoint linkedPoint = null;
        private Room myRoom = null;

        private bool isDisabled = false;

        private readonly Vector3 spawnOffset = new Vector3(0f, 0.5f, 0f);

        public Directions ExitDirection => exitDirection;
        public bool IsLinked => linkedPoint != null;
        public bool IsDisabled
        {
            get { return isDisabled; }
            set
            {
                gameObject.SetActive(false);
                isDisabled = value;
            }
        }
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
                    if (teleportPoint.ExitDirection.Opposite() == exitDirection)
                    {
                        Link(teleportPoint);
                        teleportPoint.Link(this);
                        return;
                    }
                }
            }
        }

        public void Link(TeleportPoint teleportPoint)
        {
            linkedPoint = teleportPoint;

            SetRoomTypeColour();
        }

        private void SetRoomTypeColour() => GetComponent<Renderer>().material.color = linkedPoint.Room.RoomType.RoomTypeColour;

        public override void Interact(GameObject other)
        {
            other.transform.MoveCharacterController(linkedPoint.transform.position + spawnOffset);
            linkedPoint.Room.Enter();
        }

        private void OnDrawGizmos()
        {
            if (linkedPoint != null)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, linkedPoint.transform.position);
            }
        }
    }
}
