using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Int Event", menuName = "Game Events/Int Event")]
    public class IntEvent : BaseGameEvent<int> { }
}
