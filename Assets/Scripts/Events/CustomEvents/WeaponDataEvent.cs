using Roguelike.Weapons;
using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Weapon Data Event", menuName = "Game Events/Weapon Data Event")]
    public class WeaponDataEvent : BaseGameEvent<WeaponData> { }
}
