using Roguelike.Interactables;
using Roguelike.LevelGeneration;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Rooms
{
    public class Room : MonoBehaviour
    {
        [Required] [SerializeField] private RoomType roomType = null;
        [SerializeField] private TeleportPoint[] teleportPoints = new TeleportPoint[0];
        [SerializeField] private UnityEvent onRoomStart = null;

        private bool hasEntered = false;
        private RoomObjective[] roomObjectives = new RoomObjective[0];

        public RoomType RoomType => roomType;
        public TeleportPoint[] TeleportPoints => teleportPoints;
        public LevelSettings LevelSettings { get; private set; } = null;


        [Button]
        private void GetTeleportPoints() => teleportPoints = GetComponentsInChildren<TeleportPoint>();

        private void Start() => roomObjectives = GetComponents<RoomObjective>();

        public void Initialise(LevelSettings levelSettings) => LevelSettings = levelSettings;

        public void Enter()
        {
            if (hasEntered) { return; }

            hasEntered = true;

            if (roomObjectives.Length == 0) { return; }

            ToggleTeleportPoints(false);

            InitialiseObjectives();

            onRoomStart?.Invoke();
        }

        private void InitialiseObjectives()
        {
            for (int i = 0; i < roomObjectives.Length; i++)
            {
                roomObjectives[i].onObjectiveCompleted += CheckAllObjectives;
            }
        }

        private void CheckAllObjectives()
        {
            for (int i = 0; i < roomObjectives.Length; i++)
            {
                if (!roomObjectives[i].IsComplete()) { return; }
            }

            ToggleTeleportPoints(true);
        }

        public TeleportPoint GetOpposingPoint(TeleportPoint teleportPoint)
        {
            Directions opposingDirection = teleportPoint.ExitDirection.Opposite();

            for (int i = 0; i < teleportPoints.Length; i++)
            {
                if (teleportPoints[i].ExitDirection == opposingDirection)
                {
                    return teleportPoints[i];
                }
            }

            return null;
        }

        public void ToggleTeleportPoints(bool toggle)
        {
            for (int i = 0; i < teleportPoints.Length; i++)
            {
                if (!teleportPoints[i].IsDisabled)
                {
                    teleportPoints[i].gameObject.SetActive(toggle);
                }
            }
        }
    }
}
