using Roguelike.Utilities;
using System.Collections;
using UnityEngine;

namespace Roguelike.Rooms
{
    public class TeleportPoint : MonoBehaviour
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

        private void SetRoomTypeColour()
        {
            GetComponent<Renderer>().material.color = linkedPoint.Room.RoomType.RoomTypeColour;
        }

        private void OnTriggerEnter(Collider other) => StartCoroutine(WaitForTeleport(other.transform));

        private void OnTriggerExit(Collider other) => StopAllCoroutines();

        private IEnumerator WaitForTeleport(Transform player)
        {
            while (!Input.GetKeyDown(KeyCode.F))
            {
                yield return null;
            }

            player.MoveCharacterController(linkedPoint.transform.position + spawnOffset);
        }

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
