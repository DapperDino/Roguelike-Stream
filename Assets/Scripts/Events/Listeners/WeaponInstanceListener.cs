using Roguelike.Events.CustomEvents;
using Roguelike.Events.UnityEvents;
using Roguelike.Weapons;

namespace Roguelike.Events.Listeners
{
    public class WeaponInstanceListener : BaseGameEventListener<WeaponInstance, WeaponInstanceEvent, UnityWeaponInstanceEvent> { }
}
