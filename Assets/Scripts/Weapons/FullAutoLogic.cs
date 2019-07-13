namespace Roguelike.Weapons
{
    public class FullAutoLogic : PlayerWeaponLogic
    {
        private void Update()
        {
            if (inputContainer.FireButton) { Fire(); }
        }
    }
}
