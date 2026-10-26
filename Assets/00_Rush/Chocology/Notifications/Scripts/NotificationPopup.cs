using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.Notifications
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "NotificationPopup")]
    public class NotificationPopup : MonoBehaviour
    {
        private static global::Rush.Chocology.Notifications.NotificationPopup s_Instance;
        public static global::Rush.Chocology.Notifications.NotificationPopup Instance { get => s_Instance; set => s_Instance = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("itemNotificationPrefab")]
        [UnityEngine.SerializeField]
        private global::Rush.Chocology.Notifications.ItemNotification m_ItemNotificationPrefab;
        public global::Rush.Chocology.Notifications.ItemNotification ItemNotificationPrefab { get => m_ItemNotificationPrefab; set => m_ItemNotificationPrefab = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void AddNotification(string content) => AddNotificationInternal(content);
        private void AddNotificationInternal(string content)
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundNotification();
            global::Rush.Chocology.Notifications.ItemNotification itemNotification = Instantiate(m_ItemNotificationPrefab, gameObject.transform);
            itemNotification.ShowNotification(content);
        }
    }
}
