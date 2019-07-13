namespace Roguelike.Weapons
{
    public class SemiAutoLogic : PlayerWeaponLogic
    {
        private void Update()
        {
            if (inputContainer.FireButtonDown) { Fire(); }
        }
    }
}
