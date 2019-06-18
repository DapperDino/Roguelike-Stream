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
    }
}
