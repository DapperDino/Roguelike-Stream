using UnityEngine;

namespace Roguelike.Rooms
{
    [CreateAssetMenu(fileName = "New Room Type", menuName = "Rooms/Room Type")]
    public class RoomType : ScriptableObject
    {
        [SerializeField] private string roomTypeName = "New Room Type Name";
        [SerializeField] private Color roomTypeColour = new Color(0f, 0f, 0f, 1f);

        public Color RoomTypeColour => roomTypeColour;
    }
}