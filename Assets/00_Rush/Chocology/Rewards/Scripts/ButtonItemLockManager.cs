using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ButtonItemLockManager")]
    public class ButtonItemLockManager : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ButtonItemLockManagerField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("listObj_Opens")]
            [UnityEngine.SerializeField]
            private List<GameObject> m_ListObjOpens;
            public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListObjOpens { get => m_ListObjOpens; set => m_ListObjOpens = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listObj_Locks")]
            [UnityEngine.SerializeField]
            private List<GameObject> m_ListObjLocks;
            public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListObjLocks { get => m_ListObjLocks; set => m_ListObjLocks = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("addObj")]
            [UnityEngine.SerializeField]
            private GameObject m_AddObj;
            public global::UnityEngine.GameObject AddObj { get => m_AddObj; set => m_AddObj = value; }
        }

        [global::UnityEngine.SerializeField]
        private ButtonItemLockManagerField m_ButtonItemLockManagerFields = new ButtonItemLockManagerField();
        public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListObjOpens { get => m_ButtonItemLockManagerFields.ListObjOpens; set => m_ButtonItemLockManagerFields.ListObjOpens = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListObjLocks { get => m_ButtonItemLockManagerFields.ListObjLocks; set => m_ButtonItemLockManagerFields.ListObjLocks = value; }
        public global::UnityEngine.GameObject AddObj { get => m_ButtonItemLockManagerFields.AddObj; set => m_ButtonItemLockManagerFields.AddObj = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_ButtonItemLockManagerFields.AddObj.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void ShowButtonItemLock(bool isLock) => ShowButtonItemLockInternal(isLock);
        private void ShowButtonItemLockInternal(bool isLock)
        {
            for (int i = 0; i < m_ButtonItemLockManagerFields.ListObjLocks.Count; i++)
            {
                m_ButtonItemLockManagerFields.ListObjLocks[i].gameObject.SetActive(isLock);
            }

            for (int i = 0; i < m_ButtonItemLockManagerFields.ListObjOpens.Count; i++)
            {
                m_ButtonItemLockManagerFields.ListObjOpens[i].gameObject.SetActive(!isLock);
            }

            m_ButtonItemLockManagerFields.AddObj.SetActive(false);
        }

        public void ShowAddIcon() => ShowAddIconInternal();
        private void ShowAddIconInternal()
        {
            for (int i = 0; i < m_ButtonItemLockManagerFields.ListObjLocks.Count; i++)
            {
                m_ButtonItemLockManagerFields.ListObjLocks[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < m_ButtonItemLockManagerFields.ListObjOpens.Count; i++)
            {
                m_ButtonItemLockManagerFields.ListObjOpens[i].gameObject.SetActive(false);
            }

            m_ButtonItemLockManagerFields.AddObj.SetActive(true);
        }
    }
}
