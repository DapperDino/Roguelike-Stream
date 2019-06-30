using Roguelike.Events.CustomEvents;
using Roguelike.Items;
using Sirenix.OdinInspector;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Roguelike.Utilities
{
    public class ConsoleCommandsSystem : MonoBehaviour
    {
        [Required] [SerializeField] private TMP_InputField inputField = null;

        [Header("Give")]
        [Required] [SerializeField] private ItemDatabase itemDatabase = null;
        [Required] [SerializeField] private Inventory inventory = null;

        [Header("Regenerate")]
        [Required] [SerializeField] private VoidEvent onRegenerateCommand = null;

        private const string Prefix = "/";

        private void Start()
        {
            inputField.onSubmit.AddListener(CheckInput);
        }

        public void CheckInput(string input)
        {
            if (!input.StartsWith(Prefix)) { return; }

            input = input.Substring(1);

            string[] allWords = input.ToLower().Split(' ');

            string commandWord = allWords[0];
            string[] args = allWords.Skip(1).ToArray();

            EvaluateCommandWord(ref commandWord, ref args);

            inputField.text = "";
        }

        private void EvaluateCommandWord(ref string commandWord, ref string[] args)
        {
            switch (commandWord)
            {
                case "give":
                    GiveCommand(ref args);
                    break;

                case "regenerate":
                    RegenerateCommand();
                    break;
            }
        }

        private void GiveCommand(ref string[] args)
        {
            if (args.Length < 1) { return; }

            Item desiredItem = itemDatabase.GetItemByName(string.Join(" ", args));

            if (desiredItem == null) { return; }

            inventory.AddItem(desiredItem);
        }

        private void RegenerateCommand()
        {
            onRegenerateCommand.Raise();
        }
    }
}
