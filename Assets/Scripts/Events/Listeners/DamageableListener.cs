using Roguelike.Combat;
using Roguelike.Events.CustomEvents;
using Roguelike.Events.UnityEvents;

namespace Roguelike.Events.Listeners
{
    public class DamageableListener : BaseGameEventListener<HealthSystem, DamageableEvent, UnityDamageableEvent> { }
}
