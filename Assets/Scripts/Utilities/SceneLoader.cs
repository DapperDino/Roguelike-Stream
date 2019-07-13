using UnityEngine;
using UnityEngine.SceneManagement;

namespace Roguelike.Utilities
{
    public class SceneLoader : MonoBehaviour
    {
        public void GoToScene(int sceneBuildIndex) => SceneManager.LoadScene(sceneBuildIndex);
        public void GoToScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}
