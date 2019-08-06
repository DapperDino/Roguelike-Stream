using Roguelike.Characters;

namespace Roguelike.GameStates
{
    public static class GameState
    {
        public static Character SelectedCharacter = null;
        public static float GameStartTime = 0f;

        public static void Reset()
        {
            SelectedCharacter = null;
            GameStartTime = 0f;
        }
    }
}
