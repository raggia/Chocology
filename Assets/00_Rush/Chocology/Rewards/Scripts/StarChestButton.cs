using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "StarChestButton")]
    public class StarChestButton : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class StarChestButtonField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnChest")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnChest;
            public global::BBUIButton BtnChest { get => m_BtnChest; set => m_BtnChest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtChest")]
            [UnityEngine.SerializeField]
            private Text m_TxtChest;
            public global::UnityEngine.UI.Text TxtChest { get => m_TxtChest; set => m_TxtChest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("imgChest")]
            [UnityEngine.SerializeField]
            private Image m_ImgChest;
            public global::UnityEngine.UI.Image ImgChest { get => m_ImgChest; set => m_ImgChest = value; }
        }

        [global::UnityEngine.SerializeField]
        private StarChestButtonField m_StarChestButtonFields = new StarChestButtonField();
        public global::BBUIButton BtnChest { get => m_StarChestButtonFields.BtnChest; set => m_StarChestButtonFields.BtnChest = value; }
        public global::UnityEngine.UI.Text TxtChest { get => m_StarChestButtonFields.TxtChest; set => m_StarChestButtonFields.TxtChest = value; }
        public global::UnityEngine.UI.Image ImgChest { get => m_StarChestButtonFields.ImgChest; set => m_StarChestButtonFields.ImgChest = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_StarChestButtonFields.BtnChest.OnPointerClickCallBack_Completed.AddListener(TouchChest);
            InitButton();
        }

        private void OnDestroy()
        {
            m_StarChestButtonFields.BtnChest.OnPointerClickCallBack_Completed.RemoveAllListeners();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void InitButton()
        {
            m_StarChestButtonFields.TxtChest.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar)}/{(global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)}";
            m_StarChestButtonFields.ImgChest.fillAmount = 0f;
            m_StarChestButtonFields.ImgChest.DOFillAmount(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar * 1f / global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax, 0.2f);
            if (global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar >= global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)
            {
                m_StarChestButtonFields.BtnChest.Interactable = true;
            }
            else
            {
                DOTween.Kill(m_StarChestButtonFields.BtnChest.transform);
                m_StarChestButtonFields.BtnChest.transform.localScale = Vector3.one;
                m_StarChestButtonFields.BtnChest.Interactable = false;
            }
        }

        public void SetAnimation() => SetAnimationInternal();
        private void SetAnimationInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar >= global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)
            {
                m_StarChestButtonFields.BtnChest.transform.DOScale(0.1f, 0.3f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            }
        }

        private void TouchChest()
        {
            m_StarChestButtonFields.BtnChest.Interactable = false;
            global::Rush.Chocology.Economy.Config.Runtime.SetChestCountStar(0);
            m_StarChestButtonFields.TxtChest.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar)}/{(global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)}";
            m_StarChestButtonFields.ImgChest.fillAmount = 0f;
            DOTween.Kill(m_StarChestButtonFields.BtnChest.transform);
            global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenChestPopup(true);
        }
    }
}
