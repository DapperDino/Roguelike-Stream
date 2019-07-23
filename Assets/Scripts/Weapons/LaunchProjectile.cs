using Roguelike.Combat.Stats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Weapons
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] private float spread = 0f;
        [SerializeField] private int projectilesPerShot = 1;
        [Required] [SerializeField] private GameObject projectile = null;
        [Required] [SerializeField] private Transform projectileSpawnPoint = null;
        [SerializeField] private Vector3 launchVelocity = new Vector3();

        private StatsContainer statsContainer = null;

        private void Start()
        {
            statsContainer = GetComponentInParent<StatsContainer>();
        }

        public void Launch()
        {
            for (int i = 0; i < projectilesPerShot; i++)
            {
                GameObject projectileInstance = Instantiate(
                    projectile,
                    projectileSpawnPoint.position,
                    projectileSpawnPoint.rotation);

                projectileInstance.transform.localScale *= statsContainer == null ?
                    1f :
                    1 + statsContainer.GetStatValue(StatTypes.ProjectileSizeMultiplier);

                if (launchVelocity != Vector3.zero)
                {
                    projectileInstance.GetComponent<Rigidbody>()
                        .velocity = GetRandomLaunchVelocity();
                }
            }
        }

        private Vector3 GetRandomLaunchVelocity()
        {
            float randomSpread = Random.Range(-spread / 2, spread / 2);

            Vector3 velocity = transform.TransformDirection(Quaternion.Euler(0f, randomSpread, 0) * launchVelocity);

            velocity *= statsContainer == null ?
                1f :
                1 + statsContainer.GetStatValue(StatTypes.ProjectileSpeedMultiplier);

            return velocity;
        }
    }
}
