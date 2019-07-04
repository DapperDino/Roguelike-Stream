using Roguelike.Combat;
using Roguelike.Combat.Enemies;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Roguelike.Rooms
{
    [RequireComponent(typeof(Room))]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float radius = 10;
        [SerializeField] private List<EnemyDamageable> enemies = new List<EnemyDamageable>();

        private List<EnemyDamageable> enemyInstances = new List<EnemyDamageable>();
        private Room room = null;

        private void Awake() => room = GetComponent<Room>();
        private void OnEnable() => room.onRoomFirstEntered += Spawn;
        private void OnDisable() => room.onRoomFirstEntered -= Spawn;

        public void Spawn()
        {
            room.ToggleTeleportPoints(false);

            enemyInstances = new List<EnemyDamageable>();

            for (int i = 0; i < enemies.Count; i++)
            {
                Vector3 randomPosition = transform.position + (UnityEngine.Random.insideUnitSphere * radius);

                if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, radius, NavMesh.AllAreas))
                {
                    GameObject enemyInstance = Instantiate(enemies[i], hit.position, Quaternion.identity).gameObject;

                    EnemyDamageable enemyDamageable = enemyInstance.GetComponent<EnemyDamageable>();
                    enemyDamageable.onDeath += EnemyDeath;

                    EnemyLogic enemyLogic = enemyInstance.GetComponent<EnemyLogic>();
                    enemyLogic.Initialise(room.Player);

                    enemyInstances.Add(enemyDamageable);
                }
            }
        }

        private void EnemyDeath(EnemyDamageable enemy)
        {
            enemyInstances.Remove(enemy);
            if (enemyInstances.Count == 0)
            {
                room.ToggleTeleportPoints(true);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
