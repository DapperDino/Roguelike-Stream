namespace Roguelike.Weapons
{
    public class SemiAutoLogic : WeaponLogic
    {
        private void Update()
        {
            if (inputContainer.FireButtonDown) { Fire(); }
        }
    }
}
