using UnityEngine;

namespace Roguelike.Combat.StatusEffects
{
    [CreateAssetMenu(fileName = "New Status Effect Type", menuName = "Combat/Status Effects/Status Effect Type")]
    public class StatusEffectType : ScriptableObject
    {
        [SerializeField] private new string name = "New Status Effect Name";
        [SerializeField] private string description = "New Status Effect Description";

        public string Name => name;
        public string Description => description;
    }
}
