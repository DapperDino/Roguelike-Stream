using Roguelike.Combat;
using System.Collections.Generic;

namespace Roguelike.Rooms
{
    public class RoomKillObjective : RoomObjective
    {
        private List<EnemyDamageable> enemies = new List<EnemyDamageable>();

        public void AddNewEnemy(EnemyDamageable damageable)
        {
            enemies.Add(damageable);
            damageable.onDeath += RemoveEnemy;
        }

        public void RemoveEnemy(EnemyDamageable damageable)
        {
            enemies.Remove(damageable);

            if (IsComplete()) { onObjectiveCompleted?.Invoke(); }
        }

        public override bool IsComplete() => enemies.Count == 0;
    }
}
