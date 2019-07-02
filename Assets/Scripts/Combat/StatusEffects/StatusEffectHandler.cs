using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Combat.StatusEffects
{
    public class StatusEffectHandler : MonoBehaviour
    {
        private List<StatusEffect> statusEffects = new List<StatusEffect>();

        public void ApplyEffect(StatusEffect statusEffect)
        {
            if(statusEffects.Contains(statusEffect))
            statusEffects.Add(statusEffect);
        }
    }
}
