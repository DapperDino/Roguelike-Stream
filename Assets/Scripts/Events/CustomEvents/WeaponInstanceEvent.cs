using Roguelike.Weapons;
using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Weapon Instance Event", menuName = "Game Events/Weapon Instance Event")]
    public class WeaponInstanceEvent : BaseGameEvent<WeaponInstance> { }
}
