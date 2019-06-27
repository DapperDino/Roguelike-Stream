using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Utilities
{
    public class Detonator : MonoBehaviour
    {
        [SerializeField] private float lifetime = 1f;
        [SerializeField] private bool detonateOnDestory = false;
        [SerializeField] private UnityEvent onDetonation = null;

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private void OnDestroy()
        {
            if (detonateOnDestory)
            {
                onDetonation?.Invoke();
            }
        }

        public void DetonateEarly()
        {
            onDetonation?.Invoke();
            StopAllCoroutines();
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(lifetime);

            onDetonation?.Invoke();
        }
    }
}