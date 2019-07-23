using Roguelike.Combat;
using System.Collections.Generic;

namespace Roguelike.Rooms
{
    public class RoomKillObjective : RoomObjective
    {
        private List<HealthSystem> enemies = new List<HealthSystem>();

        public void AddNewEnemy(HealthSystem healthSystem)
        {
            enemies.Add(healthSystem);
            healthSystem.OnDeath.AddListener(RemoveEnemy);
        }

        public void RemoveEnemy(HealthSystem damageable)
        {
            enemies.Remove(damageable);

            if (IsComplete()) { onObjectiveCompleted?.Invoke(); }
        }

        public override bool IsComplete() => enemies.Count == 0;
    }
}
