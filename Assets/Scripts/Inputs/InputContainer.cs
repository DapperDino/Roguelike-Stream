using UnityEngine;

namespace Roguelike.Inputs
{
    [CreateAssetMenu(fileName = "New Input Container", menuName = "Inputs/Input Container")]
    public class InputContainer : ScriptableObject
    {
        [SerializeField] private string horizontalAxisName = "Horizontal";
        [SerializeField] private string verticalAxisName = "Vertical";
        [SerializeField] private string scrollAxisName = "Mouse ScrollWheel";
        [SerializeField] private string fireButtonName = "Fire";
        [SerializeField] private KeyCode interactButtonKeyCode = KeyCode.E;
        [SerializeField] private KeyCode activeItemSwitchKeyCode = KeyCode.Tab;

        public Vector2 MovementInput { get; private set; } = Vector2.zero;
        public float ScrollInput { get; private set; } = 0f;
        public bool FireButtonDown { get; private set; } = false;
        public bool FireButton { get; private set; } = false;
        public bool FireButtonUp { get; private set; } = false;
        public bool InteractButtonDown { get; private set; } = false;
        public bool ActiveItemSwitch { get; private set; } = false;

        public void GetInput()
        {
            MovementInput = new Vector2(
                Input.GetAxisRaw(horizontalAxisName),
                Input.GetAxisRaw(verticalAxisName));

            ScrollInput = Input.GetAxisRaw(scrollAxisName);

            FireButtonDown = Input.GetButtonDown(fireButtonName);
            FireButton = Input.GetButton(fireButtonName);
            FireButtonUp = Input.GetButtonUp(fireButtonName);

            InteractButtonDown = Input.GetKeyDown(interactButtonKeyCode);
            ActiveItemSwitch = Input.GetKeyDown(activeItemSwitchKeyCode);
        }

        public void Reset()
        {
            MovementInput = Vector2.zero;
            ScrollInput = 0f;
            FireButtonDown = false;
            FireButton = false;
            FireButtonUp = false;
            InteractButtonDown = false;
            ActiveItemSwitch = false;
        }
    }
}
