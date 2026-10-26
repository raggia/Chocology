/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemTile")]
    public class ItemTile : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemTileField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("bg")]
            [UnityEngine.SerializeField]
            private SpriteRenderer m_Bg;
            public global::UnityEngine.SpriteRenderer Bg { get => m_Bg; set => m_Bg = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("icon")]
            [UnityEngine.SerializeField]
            private SpriteRenderer m_Icon;
            public global::UnityEngine.SpriteRenderer Icon { get => m_Icon; set => m_Icon = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("shadow")]
            [UnityEngine.SerializeField]
            private SpriteRenderer m_Shadow;
            public global::UnityEngine.SpriteRenderer Shadow { get => m_Shadow; set => m_Shadow = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjGroup;
            public global::UnityEngine.GameObject ObjGroup { get => m_ObjGroup; set => m_ObjGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemTileCheckCollision")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.ItemTileCheckCollision m_ItemTileCheckCollision;
            public global::Rush.Chocology.Gameplay.ItemTileCheckCollision ItemTileCheckCollision { get => m_ItemTileCheckCollision; set => m_ItemTileCheckCollision = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("indexOnMap")]
            [UnityEngine.SerializeField]
            private int m_IndexOnMap;
            public int IndexOnMap { get => m_IndexOnMap; set => m_IndexOnMap = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("indexShowTile")]
            [UnityEngine.SerializeField]
            [HideInInspector]
            private int m_IndexShowTile;
            public int IndexShowTile { get => m_IndexShowTile; set => m_IndexShowTile = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("floorIndex")]
            [UnityEngine.SerializeField]
            [HideInInspector]
            private int m_FloorIndex;
            public int FloorIndex { get => m_FloorIndex; set => m_FloorIndex = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("posTile")]
            [UnityEngine.SerializeField]
            private Vector2Int m_PosTile;
            public global::UnityEngine.Vector2Int PosTile { get => m_PosTile; set => m_PosTile = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemData")]
            [UnityEngine.SerializeField]
            [HideInInspector]
            private global::Rush.Chocology.GameplayData.ItemData m_ItemData;
            public global::Rush.Chocology.GameplayData.ItemData ItemData { get => m_ItemData; set => m_ItemData = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemTileState")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.Config.ITEMTILE_STATE m_ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.START;
            public global::Rush.Chocology.Economy.Config.ITEMTILE_STATE ItemTileState { get => m_ItemTileState; set => m_ItemTileState = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemTileField m_ItemTileFields = new ItemTileField();
        private static float s_TileSize = 1.2f;
        public static float TileSize { get => s_TileSize; set => s_TileSize = value; }
        public global::UnityEngine.SpriteRenderer Bg { get => m_ItemTileFields.Bg; set => m_ItemTileFields.Bg = value; }
        public global::UnityEngine.SpriteRenderer Icon { get => m_ItemTileFields.Icon; set => m_ItemTileFields.Icon = value; }
        public global::UnityEngine.SpriteRenderer Shadow { get => m_ItemTileFields.Shadow; set => m_ItemTileFields.Shadow = value; }
        public global::UnityEngine.GameObject ObjGroup { get => m_ItemTileFields.ObjGroup; set => m_ItemTileFields.ObjGroup = value; }
        public global::Rush.Chocology.Gameplay.ItemTileCheckCollision ItemTileCheckCollision { get => m_ItemTileFields.ItemTileCheckCollision; set => m_ItemTileFields.ItemTileCheckCollision = value; }
        public int IndexOnMap { get => m_ItemTileFields.IndexOnMap; set => m_ItemTileFields.IndexOnMap = value; }
        public int IndexShowTile { get => m_ItemTileFields.IndexShowTile; set => m_ItemTileFields.IndexShowTile = value; }
        public int FloorIndex { get => m_ItemTileFields.FloorIndex; set => m_ItemTileFields.FloorIndex = value; }
        public global::UnityEngine.Vector2Int PosTile { get => m_ItemTileFields.PosTile; set => m_ItemTileFields.PosTile = value; }
        public global::Rush.Chocology.GameplayData.ItemData ItemData { get => m_ItemTileFields.ItemData; set => m_ItemTileFields.ItemData = value; }

        private float m_PZ = 0;
        private Collider2D m_TouchCollider2D;
        public global::Rush.Chocology.Economy.Config.ITEMTILE_STATE ItemTileState { get => m_ItemTileFields.ItemTileState; set => m_ItemTileFields.ItemTileState = value; }

        private void Awake()
        {
            m_TouchCollider2D = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.Collider2D>(this);
            m_TouchCollider2D.enabled = true;
            m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.START;
            m_ItemTileFields.ItemTileCheckCollision.gameObject.SetActive(false);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR
        //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
#else
        if (Input.touchCount > 0) {
            isCheckTouchCount = true;
        }

        if (Input.touchCount == 0 && isCheckTouchCount) {
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            isCheckTouchCount = false;
            if (bg.sortingLayerName.Equals("Hover"))
            {
                SetLayer_Floor();
                objGroup.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
            }
        }
#endif
        }

        private bool m_IsCheckTouchCount = false;
        public void InitTile(int _indexShow, int _indexOnMap, int _floorIndex, Vector2Int _posTile, global::Rush.Chocology.GameplayData.ItemData _itemData) => InitTileInternal(_indexShow, _indexOnMap, _floorIndex, _posTile, _itemData);
        private void InitTileInternal(int _indexShow, int _indexOnMap, int _floorIndex, Vector2Int _posTile, global::Rush.Chocology.GameplayData.ItemData _itemData)
        {
            m_ItemTileFields.IndexOnMap = _indexOnMap;
            m_ItemTileFields.IndexShowTile = _indexShow;
            m_ItemTileFields.ItemData = _itemData;
            m_ItemTileFields.FloorIndex = _floorIndex;
            m_ItemTileFields.PosTile = _posTile;
            //pZ = 800 - floorIndex * 100f + posTile.y * 2 + 2 - posTile.x * 0.1f; 
            m_PZ = 800 - m_ItemTileFields.IndexOnMap;
            m_ItemTileFields.Icon.sprite = Resources.Load<Sprite>("Sprite/" + global::Rush.Chocology.Economy.Config.Runtime.CurrTheme.ToString() + "/" + (int)m_ItemTileFields.ItemData.ItemType);
            gameObject.transform.localPosition = new Vector3(s_TileSize * m_ItemTileFields.PosTile.x, s_TileSize * m_ItemTileFields.PosTile.y, 50 - m_ItemTileFields.FloorIndex * 5);
            SetOrderLayerFloorInternal();
            SetLayerFloorInternal();
            ShowTile();
        }

        private void ShowTile()
        {
            m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.START_TO_FLOOR;
            //Debug.Log("floorIndex:"+ floorIndex);
            if (global::Rush.Chocology.Economy.Config.Runtime.ListStartMoveType[m_ItemTileFields.FloorIndex] == global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.BOTTOM)
            {
                gameObject.transform.localPosition = new Vector3(s_TileSize * m_ItemTileFields.PosTile.x, s_TileSize * m_ItemTileFields.PosTile.y - 20f, m_PZ);
            }
            else if (global::Rush.Chocology.Economy.Config.Runtime.ListStartMoveType[m_ItemTileFields.FloorIndex] == global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.TOP)
            {
                gameObject.transform.localPosition = new Vector3(s_TileSize * m_ItemTileFields.PosTile.x, s_TileSize * m_ItemTileFields.PosTile.y + 20f, m_PZ);
            }
            else if (global::Rush.Chocology.Economy.Config.Runtime.ListStartMoveType[m_ItemTileFields.FloorIndex] == global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.LEFT)
            {
                gameObject.transform.localPosition = new Vector3(s_TileSize * m_ItemTileFields.PosTile.x - 12f, s_TileSize * m_ItemTileFields.PosTile.y, m_PZ);
            }
            else if (global::Rush.Chocology.Economy.Config.Runtime.ListStartMoveType[m_ItemTileFields.FloorIndex] == global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.RIGHT)
            {
                gameObject.transform.localPosition = new Vector3(s_TileSize * m_ItemTileFields.PosTile.x + 12f, s_TileSize * m_ItemTileFields.PosTile.y, m_PZ);
            }

            //indexShowTile * 0.01f +
            gameObject.transform.DOLocalMove(new Vector3(s_TileSize * m_ItemTileFields.PosTile.x, s_TileSize * m_ItemTileFields.PosTile.y, m_PZ), 1f).SetEase(Ease.InBack).SetDelay(0.04f * m_ItemTileFields.FloorIndex).OnComplete(() =>
            {
                m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR;
                m_ItemTileFields.ItemTileCheckCollision.gameObject.SetActive(true);
            });
        }

        public void SetTouchAvaiable(bool _isTouchAvaiable) => SetTouchAvaiableInternal(_isTouchAvaiable);
        private void SetTouchAvaiableInternal(bool _isTouchAvaiable)
        {
            m_ItemTileFields.ItemTileCheckCollision.gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
            m_TouchCollider2D.enabled = _isTouchAvaiable;
        }

        private Coroutine m_RoutineActive;
        public void SetTouchEnable() => SetTouchEnableInternal();
        private void SetTouchEnableInternal()
        {
            try
            {
                if (gameObject.activeSelf)
                    SetTouchAsyncInternal();
            }
            catch
            {
            }
        }

        private void OnDisable()
        {
            SetTouchAsyncInternal();
        }

        public void SetTouchAsync() => SetTouchAsyncInternal();
        private async void SetTouchAsyncInternal()
        {
            try
            {
                await Task.Delay(100);
                SetTouchAvaiableInternal(true);
                SetShadowAvaiableInternal(false);
            }
            catch
            {
            }
        }

        public IEnumerator SetTouchAvaiableIEnumerator() => SetTouchAvaiableIEnumeratorInternal();
        private IEnumerator SetTouchAvaiableIEnumeratorInternal()
        {
            if (!gameObject.activeSelf)
            {
                StopCoroutine(m_RoutineActive);
                yield break;
            }

            yield return new WaitForSeconds(0.1f);
            SetTouchAvaiableInternal(true);
            SetShadowAvaiableInternal(false);
        }

        public void SetShadowAvaiable(bool isShadowAvaiable) => SetShadowAvaiableInternal(isShadowAvaiable);
        private void SetShadowAvaiableInternal(bool isShadowAvaiable)
        {
            m_ItemTileFields.Shadow.gameObject.SetActive(isShadowAvaiable);
        }

        public bool TouchAvaiable
        {
            get
            {
                return m_TouchCollider2D.enabled;
            }
        }

        public void OnMouseUpAsButton() => OnMouseUpAsButtonInternal();
        private void OnMouseUpAsButtonInternal()
        {
            SetTouchItemTileInternal();
        }

        private bool m_IsMouseDown = false;
        public void OnMouseDown()
        {
            m_IsMouseDown = true;
        //        Debug.Log("OnMouseDown:    " + gameObject.name);
        }

        public void OnMouseUp()
        {
            if (m_IsMouseDown)
            {
                m_IsMouseDown = false;
                SetTouchItemTileInternal();
            }

            //Debug.Log("OnMouseUp" + gameObject.name);
            //Debug.Log("bg.sortingLayerName" + bg.sortingLayerName);
            if (m_ItemTileFields.Bg.sortingLayerName.Equals("Hover"))
            {
                SetLayerFloorInternal();
                m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
            }

            if (m_IsTileTutorial)
            {
                if (m_ItemTileFields.Bg.sortingLayerName.Equals("TutHover"))
                {
                    SetLayerFloorInternal();
                    m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
                }
            }
        }

        public void SetTouchItemTile() => SetTouchItemTileInternal();
        private void SetTouchItemTileInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                if (m_ItemTileFields.ItemTileState == global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR)
                {
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial1() && !m_IsTileTutorial)
                        return;
                    if (m_IsTileTutorial)
                        global::Rush.Chocology.Gameplay.GameLevelManager.Instance.SetNextTut1(this);
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial2() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut2)
                        return;
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial3() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut3)
                        return;
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial4() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut4)
                        return;
                    if (!global::Rush.Chocology.Gameplay.GameLevelManager.Instance.IsItemTileMoveToSlot())
                    {
                        Debug.Log("Chua the chuyen xuong slot");
                        return;
                    }

                    //AudioManager.instance.Play("Click");
                    //Debug.Log("OnMouseUpAsButton" + gameObject.name);
                    //Destroy(gameObject);
                    global::Rush.Chocology.Gameplay.GamePlayManager.Instance.HideTutHandGuide();
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundBlockClick();
                    m_ItemTileFields.ItemTileCheckCollision.gameObject.SetActive(false);
                    SetLayerMoveInternal();
                    SetTouchAvaiableInternal(false);
                    SetShadowAvaiableInternal(false);
                    m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.MOVE_TO_SLOT;
                    global::Rush.Chocology.Gameplay.GameLevelManager.Instance.AddItemSlot(this);
                }
            }
        }

        private void OnMouseEnter()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                if (m_ItemTileFields.ItemTileState == global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR)
                {
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial1() && !m_IsTileTutorial)
                        return;
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial2() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut2)
                        return;
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial3() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut3)
                        return;
                    if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial4() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut4)
                        return;
#if UNITY_EDITOR
                    SetLayerHoverInternal();
                    m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.Linear);
#else
            if (Input.touchCount > 0)
                {
                    //isMouseDown = false;
                    //Debug.Log("OnMouseEnter" + gameObject.name);
                    SetLayer_Hover();
                    objGroup.transform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.Linear);
                }
#endif
                }
            }
        }

        private void OnMouseExit()
        {
            //Debug.Log("OnMouseExit" + gameObject.name);
            //if (itemTileState == Config.ITEMTILE_STATE.FLOOR)
            //{
            //    if (touchCollider2D.enabled)
            //    {
            //        Debug.Log("OnMouseExit"+gameObject.name);
            //        SetLayer_Floor();
            //        gameObject.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
            //    }
            //}
            if (m_ItemTileFields.Bg.sortingLayerName.Equals("Hover"))
            {
                SetLayerFloorInternal();
                m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
            }

            if (m_IsTileTutorial)
            {
                if (m_ItemTileFields.Bg.sortingLayerName.Equals("TutHover"))
                {
                    SetLayerFloorInternal();
                    m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
                }
            }
        }

        public void SetLayerMove() => SetLayerMoveInternal();
        private void SetLayerMoveInternal()
        {
            m_ItemTileFields.Bg.sortingLayerName = "Move";
            m_ItemTileFields.Icon.sortingLayerName = "Move";
            m_ItemTileFields.Shadow.sortingLayerName = "Move";
            if (m_IsTileTutorial)
            {
                m_ItemTileFields.Bg.sortingLayerName = "TutMove";
                m_ItemTileFields.Icon.sortingLayerName = "TutMove";
                m_ItemTileFields.Shadow.sortingLayerName = "TutMove";
            }

            m_ItemTileFields.ItemTileCheckCollision.gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
        }

        public void SetLayerHover() => SetLayerHoverInternal();
        private void SetLayerHoverInternal()
        {
            m_ItemTileFields.Bg.sortingLayerName = "Hover";
            m_ItemTileFields.Icon.sortingLayerName = "Hover";
            m_ItemTileFields.Shadow.sortingLayerName = "Hover";
            if (m_IsTileTutorial)
            {
                m_ItemTileFields.Bg.sortingLayerName = "TutHover";
                m_ItemTileFields.Icon.sortingLayerName = "TutHover";
                m_ItemTileFields.Shadow.sortingLayerName = "TutHover";
            }

            m_ItemTileFields.ItemTileCheckCollision.gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
        }

        public void SetLayerFloor() => SetLayerFloorInternal();
        private void SetLayerFloorInternal()
        {
            m_IsMouseDown = false;
            string sortingLayerName = "Floor" + (m_ItemTileFields.FloorIndex + 1);
            if (m_IsTileTutorial)
            {
                sortingLayerName = "Tut";
            }

            m_ItemTileFields.Bg.sortingLayerName = sortingLayerName;
            m_ItemTileFields.Icon.sortingLayerName = sortingLayerName;
            m_ItemTileFields.Shadow.sortingLayerName = sortingLayerName;
            m_ItemTileFields.ItemTileCheckCollision.gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
        }

        public void SetOrderLayerMove(int indexSlot) => SetOrderLayerMoveInternal(indexSlot);
        private void SetOrderLayerMoveInternal(int indexSlot)
        {
            int sortingOrder = 10 * indexSlot;
            m_ItemTileFields.Bg.sortingOrder = sortingOrder;
            m_ItemTileFields.Icon.sortingOrder = sortingOrder;
            m_ItemTileFields.Shadow.sortingOrder = sortingOrder;
        }

        public void SetOrderLayerFloor() => SetOrderLayerFloorInternal();
        private void SetOrderLayerFloorInternal()
        {
            int sortingOrder = 400 - 20 * m_ItemTileFields.PosTile.y + m_ItemTileFields.PosTile.x;
            m_ItemTileFields.Bg.sortingOrder = sortingOrder;
            m_ItemTileFields.Icon.sortingOrder = sortingOrder;
            m_ItemTileFields.Shadow.sortingOrder = sortingOrder;
        }

        private 

        Sequence m_MoveToSlotSequence;
        public void SetMoveToSlot(int indexSlot) => SetMoveToSlotInternal(indexSlot);
        private void SetMoveToSlotInternal(int indexSlot)
        {
            DOTween.Kill(gameObject.transform);
            SetOrderLayerMoveInternal(indexSlot);
            SetLayerMoveInternal();
            m_MoveToSlotSequence = DOTween.Sequence();
            m_MoveToSlotSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.OutQuad));
            m_MoveToSlotSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(new Vector3(0f, 0f, Random.Range(10f, 15f)), 0.1f));
            m_MoveToSlotSequence.Insert(0.1f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InQuad));
            m_MoveToSlotSequence.Insert(0.1f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.InQuad));
            m_MoveToSlotSequence.InsertCallback(0.1f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWind();
            });
            m_MoveToSlotSequence.Insert(0f, gameObject.transform.DOLocalMove(Vector3.zero, 0.3f).SetEase(Ease.OutQuad));
            m_MoveToSlotSequence.OnComplete(() =>
            {
                m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.SLOT;
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundBlockMoveFinish();
                global::Rush.Chocology.Gameplay.GameLevelManager.Instance.SetMoveItemSlotFinished(this);
            });
        }

        public void ResetPosSlot(int indexSlot) => ResetPosSlotInternal(indexSlot);
        private void ResetPosSlotInternal(int indexSlot)
        {
            SetOrderLayerMoveInternal(indexSlot);
        }

        private 


        Sequence m_MatchSequence;
        public void SetItemTileMatch3(System.Action itemTileSlot_Match3_CallBack) => SetItemTileMatch3Internal(itemTileSlot_Match3_CallBack);
        private void SetItemTileMatch3Internal(System.Action itemTileSlot_Match3_CallBack)
        {
            m_MatchSequence = DOTween.Sequence();
            m_MatchSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.OutQuad));
            m_MatchSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(new Vector3(0f, 0f, Random.Range(10f, 15f)), 0.1f));
            m_MatchSequence.Insert(0.1f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InQuad));
            m_MatchSequence.Insert(0.1f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.InQuad));
            m_MatchSequence.OnComplete(() =>
            {
                itemTileSlot_Match3_CallBack.Invoke();
            });
        }

        private 


        Sequence m_MoveUndoSequence;
        public void SetItemTileUndo() => SetItemTileUndoInternal();
        private void SetItemTileUndoInternal()
        {
            DOTween.Kill(gameObject.transform);
            SetOrderLayerMoveInternal(0);
            SetLayerMoveInternal();
            m_MoveUndoSequence = DOTween.Sequence();
            m_MoveUndoSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one * 1.1f, 0.05f).SetEase(Ease.OutQuad));
            m_MoveUndoSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(new Vector3(0f, 0f, Random.Range(10f, 15f)), 0.05f));
            m_MoveUndoSequence.Insert(0.05f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InQuad));
            m_MoveUndoSequence.Insert(0.05f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(Vector3.zero, 0.1f).SetEase(Ease.InQuad));
            m_MoveUndoSequence.Insert(0f, gameObject.transform.DOLocalMove(new Vector3(s_TileSize * m_ItemTileFields.PosTile.x, s_TileSize * m_ItemTileFields.PosTile.y, m_PZ), 0.2f).SetEase(Ease.OutQuad));
            m_MoveUndoSequence.OnComplete(() =>
            {
                m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR;
                SetItemTileUndoFinished();
            });
        }

        public void SetItemTileUndoNow() => SetItemTileUndoNowInternal();
        private void SetItemTileUndoNowInternal()
        {
            gameObject.transform.localPosition = new Vector3(s_TileSize * m_ItemTileFields.PosTile.x, s_TileSize * m_ItemTileFields.PosTile.y, m_PZ);
            m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR;
            SetItemTileUndoFinished();
        }

        private void SetItemTileUndoFinished()
        {
            SetTouchAvaiableInternal(true);
            SetOrderLayerFloorInternal();
            SetLayerFloorInternal();
            m_ItemTileFields.ItemTileCheckCollision.gameObject.SetActive(true);
            m_ItemTileFields.ItemTileCheckCollision.gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
        }

        private 


        Sequence m_MoveShuffleSequence;
        public void SetItemTileShuffle(global::Rush.Chocology.GameplayData.ItemData _itemData) => SetItemTileShuffleInternal(_itemData);
        private void SetItemTileShuffleInternal(global::Rush.Chocology.GameplayData.ItemData _itemData)
        {
            m_ItemTileFields.ItemData = _itemData;
            m_MoveShuffleSequence = DOTween.Sequence();
            m_MoveShuffleSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.OutQuad));
            m_MoveShuffleSequence.Insert(0f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(new Vector3(0f, 0f, Random.Range(10f, 15f)), 0.1f));
            m_MoveShuffleSequence.InsertCallback(0.1f, () =>
            {
                SetItemTileShuffleChangeItemDataInternal();
            });
            m_MoveShuffleSequence.Insert(0.1f, m_ItemTileFields.ObjGroup.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InQuad));
            m_MoveShuffleSequence.Insert(0.1f, m_ItemTileFields.ObjGroup.transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.InQuad));
            m_MoveShuffleSequence.OnComplete(() =>
            {
                SetLayerFloorInternal();
                m_ItemTileFields.ItemTileCheckCollision.gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
            });
        }

        public void SetItemTileShuffleChangeItemData() => SetItemTileShuffleChangeItemDataInternal();
        private void SetItemTileShuffleChangeItemDataInternal()
        {
            m_ItemTileFields.Icon.sprite = Resources.Load<Sprite>("Sprite/" + global::Rush.Chocology.Economy.Config.Runtime.CurrTheme.ToString() + "/" + (int)m_ItemTileFields.ItemData.ItemType);
        }


        public void SetItemTileSuggest() => SetItemTileSuggestInternal();
        private void SetItemTileSuggestInternal()
        {
            m_ItemTileFields.ItemTileCheckCollision.gameObject.SetActive(false);
            SetLayerMoveInternal();
            SetTouchAvaiableInternal(false);
            SetShadowAvaiableInternal(false);
            m_ItemTileFields.ItemTileState = global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.MOVE_TO_SLOT;
            global::Rush.Chocology.Gameplay.GameLevelManager.Instance.AddItemSlot(this);
        }

        private 


        bool m_IsTileTutorial = false;
        public void SetItemTileTut() => SetItemTileTutInternal();
        private void SetItemTileTutInternal()
        {
            m_IsTileTutorial = true;
            string sortingLayerName = "Tut";
            m_ItemTileFields.Bg.sortingLayerName = sortingLayerName;
            m_ItemTileFields.Icon.sortingLayerName = sortingLayerName;
            m_ItemTileFields.Shadow.sortingLayerName = sortingLayerName;
        }

    }
}
