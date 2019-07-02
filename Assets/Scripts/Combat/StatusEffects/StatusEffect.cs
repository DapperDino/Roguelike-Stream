using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat.StatusEffects
{
    public abstract class StatusEffect
    {
        [Required] [SerializeField] private StatusEffectType statusEffectType = null;
        [SerializeField] private int ticks = 1;
        [SerializeField] private float tickRate = 1f;
    }
}
