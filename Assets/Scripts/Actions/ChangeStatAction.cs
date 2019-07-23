using Roguelike.Combat.Stats;
using UnityEngine;

namespace Roguelike.Actions
{
    public class ChangeStatAction : MonoBehaviour
    {
        [SerializeField] private StatTypes statType = StatTypes.None;
        [SerializeField] private float modifier = 0f;

        public void Apply()
        {
            var statsContainer = GetComponentInParent<StatsContainer>();

            if (statsContainer == null) { return; }

            statsContainer.ChangeStatValue(statType, modifier);
        }

        public void Remove()
        {
            var statsContainer = GetComponentInParent<StatsContainer>();

            if (statsContainer == null) { return; }

            statsContainer.ChangeStatValue(statType, -modifier);
        }
    }
}
