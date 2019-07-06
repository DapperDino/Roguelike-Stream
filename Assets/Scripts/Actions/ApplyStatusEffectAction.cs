using Roguelike.Combat.StatusEffects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Actions
{
    public class ApplyStatusEffectAction : SerializedMonoBehaviour
    {
        [Required] [SerializeField] private StatusEffect statusEffect = null;

        public void ApplyEffect(Transform other)
        {
            StatusEffectHandler statusEffectHandler = other.GetComponent<StatusEffectHandler>();

            statusEffectHandler?.ApplyEffect(statusEffect);
        }
    }
}
