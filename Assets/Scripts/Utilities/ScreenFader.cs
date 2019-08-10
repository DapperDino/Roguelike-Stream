using System.Collections;
using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Utilities
{
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 1f;
        [Required] [SerializeField] private VoidEvent onStartFading = null;
        [Required] [SerializeField] private VoidEvent onFadedToBlack = null;
        [Required] [SerializeField] private VoidEvent onEndFading = null;
        [SerializeField] private CanvasGroup canvasGroup = null;

        private static ScreenFader instance = null;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            else if (instance != this)
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }

        public void FadeOut()
        {
            onStartFading.Raise();
            StartCoroutine(Fade(true));
        }

        public void FadeIn()
        {
            onStartFading.Raise();
            StartCoroutine(Fade(false));
        }

        private IEnumerator Fade(bool fadeOut)
        {
            canvasGroup.blocksRaycasts = true;

            float startingAlpha = canvasGroup.alpha;
            int targetAlpha = fadeOut ? 1 : 0;

            for (float t = 0.01f; t < fadeDuration; t += Time.deltaTime)
            {
                t += Time.deltaTime;
                t = Mathf.Min(t, fadeDuration);
                canvasGroup.alpha = Mathf.Lerp(startingAlpha, targetAlpha, Mathf.Min(1, t / fadeDuration));
                yield return null;
            }

            if (targetAlpha == 1)
            {
                onFadedToBlack.Raise();
            }

            onEndFading.Raise();

            canvasGroup.blocksRaycasts = false;
        }
    }
}
