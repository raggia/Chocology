/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using DG.Tweening;
using Mkey;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Rush.Chocology.LevelMap
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "LevelPopup")]
    public class LevelPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class LevelPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCounStar")]
            [UnityEngine.SerializeField]
            private Text m_TxtCounStar;
            public global::UnityEngine.UI.Text TxtCounStar { get => m_TxtCounStar; set => m_TxtCounStar = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("mapMaker")]
            [UnityEngine.SerializeField]
            private Mkey.MapMaker m_MapMaker;
            public global::Mkey.MapMaker MapMaker { get => m_MapMaker; set => m_MapMaker = value; }
        }

        [global::UnityEngine.SerializeField]
        private LevelPopupField m_LevelPopupFields = new LevelPopupField();
        private static global::Rush.Chocology.LevelMap.LevelPopup s_Instance;
        public static global::Rush.Chocology.LevelMap.LevelPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_LevelPopupFields.BtnClose; set => m_LevelPopupFields.BtnClose = value; }
        public global::UnityEngine.GameObject Popup { get => m_LevelPopupFields.Popup; set => m_LevelPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_LevelPopupFields.LockGroup; set => m_LevelPopupFields.LockGroup = value; }
        public global::UnityEngine.UI.Text TxtCounStar { get => m_LevelPopupFields.TxtCounStar; set => m_LevelPopupFields.TxtCounStar = value; }
        public global::Mkey.MapMaker MapMaker { get => m_LevelPopupFields.MapMaker; set => m_LevelPopupFields.MapMaker = value; }
        public bool DoneCreateMap { get; set; }

        //public ScrollRect scrollRect;
        //public Transform content;
        //public ItemLevel itemLevelPrefab;
        private void Awake()
        {
            s_Instance = this;
        }

        enum LEVELPOPUP_ACTION_TYPE
        {
            SelectLevel,
            Close
        }

        private global::Rush.Chocology.LevelMap.LevelPopup.LEVELPOPUP_ACTION_TYPE m_TypeAction = global::Rush.Chocology.LevelMap.LevelPopup.LEVELPOPUP_ACTION_TYPE.Close;
        // Start is called before the first frame update
        void Start()
        {
            m_LevelPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LevelPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        // Update is called once per frame
        void Update()
        {
        //if (isShowView) {
        //    scrollRect.velocity = Vector2.zero;
        //}
        }

        public void ShowLevelPopup() => ShowLevelPopupInternal();
        private void ShowLevelPopupInternal()
        {
            gameObject.SetActive(true);
            InitViewsInternal();
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            m_TypeAction = global::Rush.Chocology.LevelMap.LevelPopup.LEVELPOPUP_ACTION_TYPE.Close;
            m_LevelPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LevelPopupFields.Popup).HideView();
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null && global::Rush.Chocology.Gameplay.GamePlayManager.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUnPause();
            }
        }

        private global::Rush.Chocology.Gameplay.InfoLevel m_InfoLevelSelect;
        public void SelectLevel(global::Rush.Chocology.Gameplay.InfoLevel infoLevel) => SelectLevelInternal(infoLevel);
        private void SelectLevelInternal(global::Rush.Chocology.Gameplay.InfoLevel infoLevel)
        {
            m_InfoLevelSelect = infoLevel;
            m_TypeAction = global::Rush.Chocology.LevelMap.LevelPopup.LEVELPOPUP_ACTION_TYPE.SelectLevel;
            m_LevelPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LevelPopupFields.Popup).HideView();
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            if (m_TypeAction == global::Rush.Chocology.LevelMap.LevelPopup.LEVELPOPUP_ACTION_TYPE.SelectLevel)
            {
                global::Rush.Chocology.Economy.Config.Runtime.IsSelectLevel = true;
                global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel = m_InfoLevelSelect.Level;
                {
                    SceneManager.LoadScene("Play");
                }
            }

            gameObject.SetActive(false);
        }

        //bool isShowView = false;
        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            //isShowView = true;
            m_LevelPopupFields.LockGroup.gameObject.SetActive(false);
            m_LevelPopupFields.Popup.gameObject.SetActive(false);
            m_LevelPopupFields.BtnClose.gameObject.SetActive(false);
            m_LevelPopupFields.TxtCounStar.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.CountStars)}/{(global::Rush.Chocology.Economy.Config.MAX_LEVEL * 3)}";
            //foreach (Transform child in content)
            //{
            //    Destroy(child.gameObject);
            //}
            InitViewShowViewInternal();
        }

        public void InitLevels() => InitLevelsInternal();
        private void InitLevelsInternal()
        {
            int currentMap = 0;
            global::Rush.Chocology.Economy.Config.Runtime.LoadCurrLevel();
            if (m_LevelPopupFields.MapMaker.biomes.Count == 0)
            {
                m_LevelPopupFields.MapMaker.biomes = m_LevelPopupFields.MapMaker.GetComponentsInChildren<Biome>().ToList();
                for (int i = 0; i < m_LevelPopupFields.MapMaker.biomes.Count; i++)
                {
                    //swap
                    if (i < (m_LevelPopupFields.MapMaker.biomes.Count - 1 - i))
                    {
                        break;
                    }

                    var temp = m_LevelPopupFields.MapMaker.biomes[i];
                    m_LevelPopupFields.MapMaker.biomes[i] = m_LevelPopupFields.MapMaker.biomes[m_LevelPopupFields.MapMaker.biomes.Count - 1 - i];
                    m_LevelPopupFields.MapMaker.biomes[m_LevelPopupFields.MapMaker.biomes.Count - 1 - i] = temp;
                }
            }

            if (!DoneCreateMap)
                foreach (var a in m_LevelPopupFields.MapMaker.biomes)
                {
                    //spawn the map button
                    a.Create();
                    a.snapButtonsToCurve = true;
                    a.SetButtonsPositionOnCurve();
                }

            if (!DoneCreateMap)
            {
                DoneCreateMap = true;
                int currentlvl = 1;
                for (int map = m_LevelPopupFields.MapMaker.biomes.Count - 1; map >= 0; map--)
                {
                    int indexMap = map;
                    int startLevel = (currentMap) * m_LevelPopupFields.MapMaker.biomes[indexMap].count + 1;
                    int endLevel = startLevel + m_LevelPopupFields.MapMaker.biomes[indexMap].count;
                    foreach (var lvlButton in m_LevelPopupFields.MapMaker.biomes[indexMap].levelButtons)
                    {
                        lvlButton.SetActive(false, 0, false);
                        lvlButton.numberText.text = currentlvl.ToString();
                        lvlButton.button.onClick.AddListener(() => global::Rush.Chocology.LevelMap.MenuManager.Instance.SelectLevel(int.Parse(lvlButton.numberText.text)));
                        if (global::Rush.Chocology.Economy.Config.Runtime.CurrLevel >= currentlvl)
                        {
                            lvlButton.SetActive(true, global::Rush.Chocology.Economy.Config.Runtime.LevelStar(currentlvl), true);
                        }
                        else
                        {
                            lvlButton.SetActive(false, global::Rush.Chocology.Economy.Config.Runtime.LevelStar(currentlvl), false);
                        }

                        currentlvl++;
                    }

                    currentMap++;
                }
            }

            MapController.Instance.SetActiveButton();
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.01f, () =>
            {
                m_LevelPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LevelPopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                m_LevelPopupFields.BtnClose.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LevelPopupFields.BtnClose.gameObject).ShowView();
                InitLevelsInternal();
            });
        }
    }
}
