using UnityEditor;
using UnityEngine;

namespace Roguelike.Utilities
{
    public class ExitGame : MonoBehaviour
    {
        public void Trigger()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
