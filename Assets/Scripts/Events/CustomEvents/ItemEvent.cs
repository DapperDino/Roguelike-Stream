using Roguelike.Items;
using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Item Event", menuName = "Game Events/Item Event")]
    public class ItemEvent : BaseGameEvent<Item> { }
}
