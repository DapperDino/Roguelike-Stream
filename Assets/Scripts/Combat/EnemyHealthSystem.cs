namespace Roguelike.Combat
{
    public class EnemyHealthSystem : HealthSystem
    {
        public override void Die()
        {
            base.Die();

            Destroy(gameObject);
        }
    }
}
