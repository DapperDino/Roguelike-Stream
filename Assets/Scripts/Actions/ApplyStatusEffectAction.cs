using Roguelike.Combat.StatusEffects;
using UnityEngine;

namespace Roguelike.Actions
{
    public class ApplyStatusEffectAction : MonoBehaviour
    {
        [SerializeField] private StatusEffect statusEffect = null;

        public void ApplyEffect(Transform other)
        {
            StatusEffectHandler statusEffectHandler = other.GetComponent<StatusEffectHandler>();

            statusEffectHandler?.ApplyEffect(statusEffect);
        }
    }
}
