using System;

namespace Roguelike.Items
{
    [Serializable]
    public class PassiveItemInstance
    {
        public Item item = null;
        public PassiveItemLogic passiveLogic = null;
    }
}