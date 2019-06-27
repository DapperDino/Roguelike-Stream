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

        public void Launch()
        {
            for (int i = 0; i < projectilesPerShot; i++)
            {
                GameObject projectileInstance = Instantiate(
                    projectile,
                    projectileSpawnPoint.position,
                    projectileSpawnPoint.rotation);

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
            return transform.TransformDirection(Quaternion.Euler(0f, randomSpread, 0) * launchVelocity);
        }
    }
}
