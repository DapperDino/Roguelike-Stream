using UnityEngine;

namespace Roguelike.Notifications
{
    public interface INotifiable
    {
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }
    }
}