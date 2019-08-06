using System.Collections;
using Roguelike.GameStates;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Roguelike.Characters
{
    public class CharacterSelectionSystem : MonoBehaviour
    {
        [Header("Characters")]
        [SerializeField] private Character[] characters = new Character[0];

        [Header("Spawn Settings")]
        [SerializeField] private float rotationDuration = 1f;
        [SerializeField] private float spawnRadius = 3f;
        [Required] [SerializeField] private Transform characterHolderTransform = null;

        [Header("UI")]
        [Required] [SerializeField] private TextMeshProUGUI characterNameText = null;

        private int selectedCharacterIndex = 0;
        private Character SelectedCharacter => characters[selectedCharacterIndex];
        private Coroutine rotationCoroutine = null;

        private void Start()
        {
            SpawnCharacters();

            characterNameText.text = SelectedCharacter.Name;
        }

        public void ChangeSelectedCharacter(bool rightButton)
        {
            if (rotationCoroutine != null) { return; }

            rotationCoroutine = StartCoroutine(RotateCharacters(rightButton));

            selectedCharacterIndex += rightButton ? 1 : -1;

            if (selectedCharacterIndex < 0) { selectedCharacterIndex = characters.Length - 1; }
            else if (selectedCharacterIndex == characters.Length) { selectedCharacterIndex = 0; }

            characterNameText.text = SelectedCharacter.Name;
        }

        public void SelectCharacter()
        {
            GameState.SelectedCharacter = SelectedCharacter;
            GameState.GameStartTime = Time.time;
        }

        private void SpawnCharacters()
        {
            for (int i = 0; i < characters.Length; i++)
            {
                float angle = i * Mathf.PI * 2 / characters.Length;
                Vector3 spawnPos = characterHolderTransform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * spawnRadius;
                Quaternion spawnRot = Quaternion.LookRotation(spawnPos - characterHolderTransform.position);
                Instantiate(
                    characters[i].Visuals,
                    spawnPos,
                    spawnRot,
                    characterHolderTransform);
            }
        }

        private IEnumerator RotateCharacters(bool rightButton)
        {
            float angle = 360 / characters.Length;
            if (!rightButton) { angle = -angle; }

            float startingY = characterHolderTransform.localEulerAngles.y;
            float endingY = startingY + angle;

            float startTime = Time.time;

            while (Time.time - startTime < rotationDuration)
            {
                characterHolderTransform.Rotate(0f, (angle / rotationDuration) * Time.deltaTime, 0f);
                yield return null;
            }

            characterHolderTransform.rotation = Quaternion.Euler(0f, endingY, 0f);

            rotationCoroutine = null;
        }
    }
}
