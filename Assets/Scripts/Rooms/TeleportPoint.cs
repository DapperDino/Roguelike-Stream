using Roguelike.Utilities;
using System.Collections;
using UnityEngine;

namespace Roguelike.Rooms
{
    public class TeleportPoint : MonoBehaviour
    {
        [SerializeField] private Vector3 spawnOffset = new Vector3(0f, 0.5f, 0f);
        [SerializeField] private TeleportPoint teleportPoint = null;

        public bool IsLinked => teleportPoint != null;

        public void Link(Room room)
        {
            foreach (TeleportPoint teleportPoint in room.TeleportPoints)
            {
                if (!teleportPoint.IsLinked)
                {
                    this.teleportPoint = teleportPoint;
                    teleportPoint.Link(this);
                    return;
                }
            }
        }

        public void Link(TeleportPoint teleportPoint) => this.teleportPoint = teleportPoint;

        private void OnTriggerEnter(Collider other) => StartCoroutine(WaitForTeleport(other.transform));

        private void OnTriggerExit(Collider other) => StopAllCoroutines();

        private IEnumerator WaitForTeleport(Transform player)
        {
            while (!Input.GetKeyDown(KeyCode.F))
            {
                yield return null;
            }

            player.MoveCharacterController(teleportPoint.transform.position + spawnOffset);
        }

        private void OnDrawGizmos()
        {
            if (teleportPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, teleportPoint.transform.position);
            }
        }
    }
}
