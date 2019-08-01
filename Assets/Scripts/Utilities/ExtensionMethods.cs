using UnityEngine;

namespace Roguelike.Utilities
{
    public static class ExtensionMethods
    {
        public static void MoveCharacterController(this Transform transform, Vector3 position)
        {
            CharacterController characterController = transform.GetComponent<CharacterController>();

            if (characterController == null) { return; }

            characterController.enabled = false;
            transform.position = position;
            characterController.enabled = true;
        }

        public static Directions Opposite(this Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    return Directions.Down;

                case Directions.Right:
                    return Directions.Left;

                case Directions.Down:
                    return Directions.Up;

                case Directions.Left:
                    return Directions.Right;
            }

            return Directions.None;
        }

        public static KeyCode[] NumKeys = new KeyCode[10]
        {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
            KeyCode.Alpha0,
        };
    }
}
