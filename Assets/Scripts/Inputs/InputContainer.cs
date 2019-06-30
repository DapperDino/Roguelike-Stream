using UnityEngine;

namespace Roguelike.Inputs
{
    [CreateAssetMenu(fileName = "New Input Container", menuName = "Inputs/Input Container")]
    public class InputContainer : ScriptableObject
    {
        [SerializeField] private string horizontalAxisName = "Horizontal";
        [SerializeField] private string verticalAxisName = "Vertical";
        [SerializeField] private string fireButtonName = "Fire";
        [SerializeField] private string interactButtonName = "Interact";

        public Vector2 MovementInput { get; private set; } = Vector2.zero;
        public bool FireButtonDown { get; private set; } = false;
        public bool FireButton { get; private set; } = false;
        public bool FireButtonUp { get; private set; } = false;
        public bool InteractButtonDown { get; private set; } = false;

        public void GetInput()
        {
            MovementInput = new Vector2(
                Input.GetAxisRaw(horizontalAxisName),
                Input.GetAxisRaw(verticalAxisName));

            FireButtonDown = Input.GetButtonDown(fireButtonName);
            FireButton = Input.GetButton(fireButtonName);
            FireButtonUp = Input.GetButtonUp(fireButtonName);

            InteractButtonDown = Input.GetButtonDown(interactButtonName);
        }

        public void Reset()
        {
            MovementInput = Vector2.zero;
            FireButtonDown = false;
            FireButton = false;
            FireButtonUp = false;
            InteractButtonDown = false;
        }
    }
}
