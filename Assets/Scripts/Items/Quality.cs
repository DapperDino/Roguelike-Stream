using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Quality", menuName = "Items/Quality")]
    public class Quality : ScriptableObject
    {
        [SerializeField] private new string name = "New Quality Name";
        [SerializeField] private Color colour = new Color(0f, 0f, 0f, 1f);

        public string Name => name;
        public Color Colour => colour;
    }
}
