using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.Notifications
{
    [RequireComponent(typeof(Animator))]
    public class NotificationSystem : MonoBehaviour
    {
        [Required] [SerializeField] private TextMeshProUGUI notificationNameText = null;
        [Required] [SerializeField] private TextMeshProUGUI notificationDescriptionText = null;
        [Required] [SerializeField] private Image notificationIconImage = null;

        private Queue<INotifiable> notifications = new Queue<INotifiable>();
        private Animator animator = null;

        private static readonly int hashNotify = Animator.StringToHash("Notify");

        private void Start() => animator = GetComponent<Animator>();

        public void AddNewNotification(INotifiable notifiable)
        {
            notifications.Enqueue(notifiable);

            if (notifications.Count == 1)
            {
                DisplayNotification(notifiable);
            }
        }

        public void FinishNotification()
        {
            notifications.Dequeue();

            if (notifications.Count > 0)
            {
                DisplayNotification(notifications.Peek());
            }
        }

        private void DisplayNotification(INotifiable notifiable)
        {
            notificationNameText.text = notifiable.Name;
            notificationDescriptionText.text = notifiable.Description;
            notificationIconImage.sprite = notifiable.Icon;

            animator.SetTrigger(hashNotify);
        }
    }
}
