using Roguelike.Events.CustomEvents;
using Roguelike.Events.UnityEvents;
using Roguelike.Items;

namespace Roguelike.Events.Listeners
{
    public class ItemListener : BaseGameEventListener<Item, ItemEvent, UnityItemEvent> { }
}
