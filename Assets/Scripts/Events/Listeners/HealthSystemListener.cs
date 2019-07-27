using Roguelike.Combat;
using Roguelike.Events.CustomEvents;
using Roguelike.Events.UnityEvents;

namespace Roguelike.Events.Listeners
{
    public class HealthSystemListener : BaseGameEventListener<HealthSystem, HealthSystemEvent, UnityHealthSystemEvent> { }
}
