namespace Roguelike.Weapons
{
    public class FullAutoLogic : WeaponLogic
    {
        private void Update()
        {
            if (inputContainer.FireButton) { Fire(); }
        }
    }
}
