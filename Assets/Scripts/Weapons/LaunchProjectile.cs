using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike.Weapons
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform projectileSpawnPoint = null;
        [SerializeField] private Vector3 launchVelocity = new Vector3();

        public void Launch()
        {
            GameObject projectileInstance = Instantiate(
                projectile,
                projectileSpawnPoint.position,
                projectileSpawnPoint.rotation);

            projectileInstance.GetComponent<TransformMovement>()
                .Initialise(transform.TransformDirection(launchVelocity));
        }
    }
}
