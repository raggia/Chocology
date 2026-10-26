using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.LevelMap
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemLevel")]
    public class ItemLevel : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemLevelField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("txtLevel")]
            [UnityEngine.SerializeField]
            private Text m_TxtLevel;
            public global::UnityEngine.UI.Text TxtLevel { get => m_TxtLevel; set => m_TxtLevel = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("iconLock")]
            [UnityEngine.SerializeField]
            private Image m_IconLock;
            public global::UnityEngine.UI.Image IconLock { get => m_IconLock; set => m_IconLock = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listStars")]
            [UnityEngine.SerializeField]
            private List<Image> m_ListStars;
            public global::System.Collections.Generic.List<global::UnityEngine.UI.Image> ListStars { get => m_ListStars; set => m_ListStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spriteStar_On")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteStarOn;
            public global::UnityEngine.Sprite SpriteStarOn { get => m_SpriteStarOn; set => m_SpriteStarOn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spriteStar_Off")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteStarOff;
            public global::UnityEngine.Sprite SpriteStarOff { get => m_SpriteStarOff; set => m_SpriteStarOff = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnLevel")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnLevel;
            public global::BBUIButton BtnLevel { get => m_BtnLevel; set => m_BtnLevel = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemLevelField m_ItemLevelFields = new ItemLevelField();
        public global::UnityEngine.UI.Text TxtLevel { get => m_ItemLevelFields.TxtLevel; set => m_ItemLevelFields.TxtLevel = value; }
        public global::UnityEngine.UI.Image IconLock { get => m_ItemLevelFields.IconLock; set => m_ItemLevelFields.IconLock = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.UI.Image> ListStars { get => m_ItemLevelFields.ListStars; set => m_ItemLevelFields.ListStars = value; }
        public global::UnityEngine.Sprite SpriteStarOn { get => m_ItemLevelFields.SpriteStarOn; set => m_ItemLevelFields.SpriteStarOn = value; }
        public global::UnityEngine.Sprite SpriteStarOff { get => m_ItemLevelFields.SpriteStarOff; set => m_ItemLevelFields.SpriteStarOff = value; }
        public global::BBUIButton BtnLevel { get => m_ItemLevelFields.BtnLevel; set => m_ItemLevelFields.BtnLevel = value; }

        private global::Rush.Chocology.Gameplay.InfoLevel m_InfoLevel;
        // Start is called before the first frame update
        void Start()
        {
            m_ItemLevelFields.BtnLevel.OnPointerClickCallBack_Completed.AddListener(TouchLevelInternal);
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void TouchLevel() => TouchLevelInternal();
        private void TouchLevelInternal()
        {
            global::Rush.Chocology.LevelMap.LevelPopup.Instance.SelectLevel(m_InfoLevel);
            global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("start_game");
        }

        //infoLevel.x == indexLevel
        //infoLevel.y == star
        public void SetInitItemLevel(global::Rush.Chocology.Gameplay.InfoLevel _infoLevel) => SetInitItemLevelInternal(_infoLevel);
        private void SetInitItemLevelInternal(global::Rush.Chocology.Gameplay.InfoLevel _infoLevel)
        {
            m_InfoLevel = _infoLevel;
            ShowInfoLevelInternal();
        }

        public void ShowInfoLevel() => ShowInfoLevelInternal();
        private void ShowInfoLevelInternal()
        {
            if (m_InfoLevel.Level < global::Rush.Chocology.Economy.Config.Runtime.CurrLevel)
            {
                //Da mo khoa
                m_ItemLevelFields.BtnLevel.Interactable = true;
                m_ItemLevelFields.IconLock.gameObject.SetActive(false);
                m_ItemLevelFields.TxtLevel.gameObject.SetActive(true);
                m_ItemLevelFields.TxtLevel.text = $"{(m_InfoLevel.Level)}";
                for (int i = 0; i < m_ItemLevelFields.ListStars.Count; i++)
                {
                    m_ItemLevelFields.ListStars[i].gameObject.SetActive(true);
                    m_ItemLevelFields.ListStars[i].sprite = m_ItemLevelFields.SpriteStarOff;
                }

                if (m_InfoLevel.Star >= 3)
                    m_InfoLevel.Star = 3;
                for (int i = 0; i < m_InfoLevel.Star; i++)
                {
                    m_ItemLevelFields.ListStars[i].gameObject.SetActive(true);
                    m_ItemLevelFields.ListStars[i].sprite = m_ItemLevelFields.SpriteStarOn;
                }
            }
            else if (m_InfoLevel.Level == global::Rush.Chocology.Economy.Config.Runtime.CurrLevel)
            {
                //CurrLevel
                m_ItemLevelFields.BtnLevel.Interactable = true;
                m_ItemLevelFields.IconLock.gameObject.SetActive(false);
                m_ItemLevelFields.TxtLevel.gameObject.SetActive(true);
                m_ItemLevelFields.TxtLevel.text = $"{(m_InfoLevel.Level)}";
                for (int i = 0; i < m_ItemLevelFields.ListStars.Count; i++)
                {
                    m_ItemLevelFields.ListStars[i].gameObject.SetActive(true);
                    m_ItemLevelFields.ListStars[i].sprite = m_ItemLevelFields.SpriteStarOff;
                }
            }
            else
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.IsHackMode)
                {
                    m_ItemLevelFields.BtnLevel.Interactable = true;
                    m_ItemLevelFields.IconLock.gameObject.SetActive(false);
                    m_ItemLevelFields.TxtLevel.gameObject.SetActive(true);
                    m_ItemLevelFields.TxtLevel.text = $"{(m_InfoLevel.Level)}";
                    for (int i = 0; i < m_ItemLevelFields.ListStars.Count; i++)
                    {
                        m_ItemLevelFields.ListStars[i].gameObject.SetActive(true);
                        m_ItemLevelFields.ListStars[i].sprite = m_ItemLevelFields.SpriteStarOff;
                    }

                    if (m_InfoLevel.Star >= 3)
                        m_InfoLevel.Star = 3;
                    for (int i = 0; i < m_InfoLevel.Star; i++)
                    {
                        m_ItemLevelFields.ListStars[i].gameObject.SetActive(true);
                        m_ItemLevelFields.ListStars[i].sprite = m_ItemLevelFields.SpriteStarOn;
                    }
                }
                else
                {
                    m_ItemLevelFields.BtnLevel.Interactable = false;
                    m_ItemLevelFields.IconLock.gameObject.SetActive(true);
                    m_ItemLevelFields.TxtLevel.gameObject.SetActive(false);
                    m_ItemLevelFields.TxtLevel.text = $"{(m_InfoLevel.Level)}";
                    for (int i = 0; i < m_ItemLevelFields.ListStars.Count; i++)
                    {
                        m_ItemLevelFields.ListStars[i].gameObject.SetActive(false);
                        m_ItemLevelFields.ListStars[i].sprite = m_ItemLevelFields.SpriteStarOff;
                    }
                }
            }
        }
    }
}
