using Roguelike.GameStates;

namespace Roguelike.Combat
{
    public class EnemyHealthSystem : HealthSystem
    {
        public override void Die()
        {
            base.Die();

            GameState.Kills++;

            Destroy(gameObject);
        }
    }
}
