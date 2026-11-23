/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
using BsplabsMobileAds;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "GameLevelManager")]
    public class GameLevelManager : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class GameLevelManagerField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("configLevelGame")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.ConfigLevelGame m_ConfigLevelGame;
            public global::Rush.Chocology.Gameplay.ConfigLevelGame ConfigLevelGame { get => m_ConfigLevelGame; set => m_ConfigLevelGame = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listItemDataOnMaps")]
            [UnityEngine.SerializeField]
            [Tooltip("Các item hiện trên map")]
            private List<global::Rush.Chocology.GameplayData.ItemData> m_ListItemDataOnMaps = new List<global::Rush.Chocology.GameplayData.ItemData>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.GameplayData.ItemData> ListItemDataOnMaps { get => m_ListItemDataOnMaps; set => m_ListItemDataOnMaps = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemTilePrefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.ItemTile m_ItemTilePrefab;
            public global::Rush.Chocology.Gameplay.ItemTile ItemTilePrefab { get => m_ItemTilePrefab; set => m_ItemTilePrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("tileMapGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_TileMapGroup;
            public global::UnityEngine.GameObject TileMapGroup { get => m_TileMapGroup; set => m_TileMapGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listTileMaps")]
            [UnityEngine.SerializeField]
            private List<Tilemap> m_ListTileMaps = new List<Tilemap>();
            public global::System.Collections.Generic.List<global::UnityEngine.Tilemaps.Tilemap> ListTileMaps { get => m_ListTileMaps; set => m_ListTileMaps = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listFloors")]
            [UnityEngine.SerializeField]
            private List<Transform> m_ListFloors = new List<Transform>();
            public global::System.Collections.Generic.List<global::UnityEngine.Transform> ListFloors { get => m_ListFloors; set => m_ListFloors = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("slotBG")]
            [UnityEngine.SerializeField]
            private GameObject m_SlotBG;
            public global::UnityEngine.GameObject SlotBG { get => m_SlotBG; set => m_SlotBG = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemTileSlotPrefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.ItemTileSlot m_ItemTileSlotPrefab;
            public global::Rush.Chocology.Gameplay.ItemTileSlot ItemTileSlotPrefab { get => m_ItemTileSlotPrefab; set => m_ItemTileSlotPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listItemSlots")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Gameplay.ItemTileSlot> m_ListItemSlots = new List<global::Rush.Chocology.Gameplay.ItemTileSlot>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTileSlot> ListItemSlots { get => m_ListItemSlots; set => m_ListItemSlots = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("slotParentTranform")]
            [UnityEngine.SerializeField]
            private Transform m_SlotParentTranform;
            public global::UnityEngine.Transform SlotParentTranform { get => m_SlotParentTranform; set => m_SlotParentTranform = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listCheckUndo_ItemTileSlots")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Gameplay.ItemTileSlot> m_ListCheckUndoItemTileSlots = new List<global::Rush.Chocology.Gameplay.ItemTileSlot>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTileSlot> ListCheckUndoItemTileSlots { get => m_ListCheckUndoItemTileSlots; set => m_ListCheckUndoItemTileSlots = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listShuffle_ItemTiles")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Gameplay.ItemTile> m_ListShuffleItemTiles = new List<global::Rush.Chocology.Gameplay.ItemTile>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile> ListShuffleItemTiles { get => m_ListShuffleItemTiles; set => m_ListShuffleItemTiles = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listSuggest_ItemTiles")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Gameplay.ItemTile> m_ListSuggestItemTiles = new List<global::Rush.Chocology.Gameplay.ItemTile>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile> ListSuggestItemTiles { get => m_ListSuggestItemTiles; set => m_ListSuggestItemTiles = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listItemTile_Tutorials")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Gameplay.ItemTile> m_ListItemTileTutorials = new List<global::Rush.Chocology.Gameplay.ItemTile>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile> ListItemTileTutorials { get => m_ListItemTileTutorials; set => m_ListItemTileTutorials = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("handGuild")]
            [UnityEngine.SerializeField]
            private GameObject m_HandGuild;
            public global::UnityEngine.GameObject HandGuild { get => m_HandGuild; set => m_HandGuild = value; }
        }

        [global::UnityEngine.SerializeField]
        private GameLevelManagerField m_GameLevelManagerFields = new GameLevelManagerField();
        private static global::Rush.Chocology.Gameplay.GameLevelManager s_Instance;
        public static global::Rush.Chocology.Gameplay.GameLevelManager Instance { get => s_Instance; set => s_Instance = value; }
        public global::Rush.Chocology.Gameplay.ConfigLevelGame ConfigLevelGame { get => m_GameLevelManagerFields.ConfigLevelGame; set => m_GameLevelManagerFields.ConfigLevelGame = value; }
        public global::System.Collections.Generic.List<global::Rush.Chocology.GameplayData.ItemData> ListItemDataOnMaps { get => m_GameLevelManagerFields.ListItemDataOnMaps; set => m_GameLevelManagerFields.ListItemDataOnMaps = value; }
        public global::Rush.Chocology.Gameplay.ItemTile ItemTilePrefab { get => m_GameLevelManagerFields.ItemTilePrefab; set => m_GameLevelManagerFields.ItemTilePrefab = value; }
        public global::UnityEngine.GameObject TileMapGroup { get => m_GameLevelManagerFields.TileMapGroup; set => m_GameLevelManagerFields.TileMapGroup = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.Tilemaps.Tilemap> ListTileMaps { get => m_GameLevelManagerFields.ListTileMaps; set => m_GameLevelManagerFields.ListTileMaps = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.Transform> ListFloors { get => m_GameLevelManagerFields.ListFloors; set => m_GameLevelManagerFields.ListFloors = value; }

        private List<global::Rush.Chocology.Gameplay.ItemTileData> m_ListItemTileDatas = new List<global::Rush.Chocology.Gameplay.ItemTileData>();
        public global::UnityEngine.GameObject SlotBG { get => m_GameLevelManagerFields.SlotBG; set => m_GameLevelManagerFields.SlotBG = value; }

        private Vector2 m_OriginalSlotBgPos;
        private void Awake()
        {
            s_Instance = this;
        //if (Config.CheckWideScreen()) {
        //    slotBG.transform.parent.localPosition = new Vector3(0f, -4.5f, 0f);
        //}
        // slotBG.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/freeitem_button") as Sprite;
        }

        private Vector3 m_PosSlotBG;
        public void InitSlotPosition(Vector3 pos) => InitSlotPositionInternal(pos);
        private void InitSlotPositionInternal(Vector3 pos)
        {
            m_PosSlotBG = pos;
            //        Debug.Log(posSlotBG);
            m_GameLevelManagerFields.SlotBG.transform.parent.position = new Vector3(0f, pos.y, 0);
        //      Debug.Log(slotBG.transform.parent.position);
        }

        // Start is called before the first frame update
        void Start()
        {
            m_GameLevelManagerFields.SlotBG.gameObject.SetActive(false);
            m_OriginalSlotBgPos = m_GameLevelManagerFields.SlotBG.transform.position;
            if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial1())
            {
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.SpriteRenderer>(m_GameLevelManagerFields.SlotBG).sortingLayerName = "TutUI";
            }

            InitListMoveTypeInternal();
            ReadDataTileMapInternal();
            StartCoroutine(ShowSlotBGInternal());
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void InitListMoveType() => InitListMoveTypeInternal();
        private void InitListMoveTypeInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.ListStartMoveType.Clear();
            List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE> listTemp_StartMoveType = new List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE>();
            listTemp_StartMoveType.Clear();
            listTemp_StartMoveType.Add(global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.TOP);
            listTemp_StartMoveType.Add(global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.BOTTOM);
            listTemp_StartMoveType.Add(global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.RIGHT);
            listTemp_StartMoveType.Add(global::Rush.Chocology.Economy.Config.START_MOVE_TYPE.LEFT);
            List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE> listTemp2_StartMoveType = new List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE>();
            listTemp2_StartMoveType.Clear();
            for (int i = 0; i < 4; i++)
            {
                global::Rush.Chocology.Economy.Config.START_MOVE_TYPE moveType = listTemp_StartMoveType[Random.Range(0, listTemp_StartMoveType.Count)];
                listTemp2_StartMoveType.Add(moveType);
                listTemp_StartMoveType.Remove(moveType);
            }

            for (int i = 0; i < m_GameLevelManagerFields.ListFloors.Count; i++)
            {
                global::Rush.Chocology.Economy.Config.Runtime.ListStartMoveType.Add(listTemp2_StartMoveType[i % 4]);
            }
        }

        public void ReadDataTileMap() => ReadDataTileMapInternal();
        private void ReadDataTileMapInternal()
        {
            // Debug.Log(listTileMaps[i].cellBounds.yMax - listTileMaps[i].cellBounds.yMin);
            m_ListItemTileDatas.Clear();
            int indexOnMap = 0;
            for (int i = 0; i < m_GameLevelManagerFields.ListTileMaps.Count; i++)
            {
                for (int y = m_GameLevelManagerFields.ListTileMaps[i].cellBounds.yMin; y < m_GameLevelManagerFields.ListTileMaps[i].cellBounds.yMax; y++)
                {
                    for (int x = m_GameLevelManagerFields.ListTileMaps[i].cellBounds.xMin; x < m_GameLevelManagerFields.ListTileMaps[i].cellBounds.xMax; x++)
                    {
                        //Debug.Log("i:" + i + "   j:" + j);
                        if (m_GameLevelManagerFields.ListTileMaps[i].HasTile(new Vector3Int(x, y, 0)))
                        {
                            indexOnMap++;
                            global::Rush.Chocology.Gameplay.ItemTileData itemTileData = new global::Rush.Chocology.Gameplay.ItemTileData(i, indexOnMap, new Vector2Int(x, y));
                            m_ListItemTileDatas.Add(itemTileData);
                        }
                    }
                }
            }

            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance.IsPlayTest)
            {
                int height = 0;
                for (int i = 0; i < m_GameLevelManagerFields.ListTileMaps.Count; i++)
                {
                    for (int x = m_GameLevelManagerFields.ListTileMaps[i].cellBounds.xMin; x < m_GameLevelManagerFields.ListTileMaps[i].cellBounds.xMax; x++)
                    {
                        int yMin = 100;
                        int yMax = -100;
                        for (int y = m_GameLevelManagerFields.ListTileMaps[i].cellBounds.yMin; y < m_GameLevelManagerFields.ListTileMaps[i].cellBounds.yMax; y++)
                        {
                            //Debug.Log("i:" + i + "   j:" + j);
                            if (m_GameLevelManagerFields.ListTileMaps[i].HasTile(new Vector3Int(x, y, 0)))
                            {
                                if (y < yMin)
                                    yMin = y;
                                if (y > yMax)
                                    yMax = y;
                            }
                        }

                        int newHeight = yMax - yMin + 1;
                        if (newHeight > height)
                            height = newHeight;
                    }
                }

                //            Debug.Log("heightheightheightheight" + height);
                if (height >= 9)
                {
                    gameObject.transform.localScale = Vector3.one;
                    gameObject.transform.localPosition = new Vector3(0f, -0.5f, 0f);
                    InitSlotPositionInternal(new Vector3(m_PosSlotBG.x, m_PosSlotBG.y, 0));
                }
            }

            m_GameLevelManagerFields.TileMapGroup.SetActive(false);
            GenerateItemDataInternal();
        }

        public void GenerateItemData() => GenerateItemDataInternal();
        private void GenerateItemDataInternal()
        {
            Debug.Log("GenerateItemDataGenerateItemData:" + m_ListItemTileDatas.Count);
            List<global::Rush.Chocology.GameplayData.ItemData> listTemp_ItemDatas = new List<global::Rush.Chocology.GameplayData.ItemData>();
            listTemp_ItemDatas.Clear();
            if (m_ListItemTileDatas.Count % 3 != 0)
            {
                Debug.LogError("Số phần tử phải là x3: " + m_ListItemTileDatas.Count);
                return;
            }

            List<global::Rush.Chocology.GameplayData.ItemData> listItemDataOnMaps_Shuffle = new List<global::Rush.Chocology.GameplayData.ItemData>();
            List<global::Rush.Chocology.GameplayData.ItemData> listItemDataOnMaps_Temp = new List<global::Rush.Chocology.GameplayData.ItemData>(m_GameLevelManagerFields.ListItemDataOnMaps);
            for (int i = 0; i < m_GameLevelManagerFields.ListItemDataOnMaps.Count; i++)
            {
                global::Rush.Chocology.GameplayData.ItemData itemData = listItemDataOnMaps_Temp[Random.Range(0, listItemDataOnMaps_Temp.Count)];
                listItemDataOnMaps_Shuffle.Add(itemData);
                listItemDataOnMaps_Temp.Remove(itemData);
            }

            for (int i = 0; i < m_ListItemTileDatas.Count / 3; i++)
            {
                global::Rush.Chocology.GameplayData.ItemData itemData = listItemDataOnMaps_Shuffle[i % listItemDataOnMaps_Shuffle.Count];
                //Add 3 phan tu
                listTemp_ItemDatas.Add(itemData);
                listTemp_ItemDatas.Add(itemData);
                listTemp_ItemDatas.Add(itemData);
            }

            // Debug.Log("1111111111111111111:" + listTemp_ItemDatas.Count);
            for (int i = 0; i < m_ListItemTileDatas.Count; i++)
            {
                global::Rush.Chocology.GameplayData.ItemData itemData = listTemp_ItemDatas[Random.Range(0, listTemp_ItemDatas.Count)];
                m_ListItemTileDatas[i].ItemData = itemData;
                listTemp_ItemDatas.Remove(itemData);
            }

            //Debug.Log("222222222222:" + listTemp_ItemDatas.Count);
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance.Level == 1)
            {
                //Tut
                int indexItemData = Random.Range(0, m_GameLevelManagerFields.ListItemDataOnMaps.Count);
                global::Rush.Chocology.Gameplay.ItemTileData itemTileData1 = new global::Rush.Chocology.Gameplay.ItemTileData(1, 100, new Vector2Int(0, 0));
                m_ListItemTileDatas.Add(itemTileData1);
                itemTileData1.ItemData = m_GameLevelManagerFields.ListItemDataOnMaps[indexItemData];
                global::Rush.Chocology.Gameplay.ItemTileData itemTileData2 = new global::Rush.Chocology.Gameplay.ItemTileData(1, 101, new Vector2Int(-1, 0));
                m_ListItemTileDatas.Add(itemTileData2);
                itemTileData2.ItemData = m_GameLevelManagerFields.ListItemDataOnMaps[indexItemData];
                global::Rush.Chocology.Gameplay.ItemTileData itemTileData3 = new global::Rush.Chocology.Gameplay.ItemTileData(1, 102, new Vector2Int(-2, 0));
                m_ListItemTileDatas.Add(itemTileData3);
                itemTileData3.ItemData = m_GameLevelManagerFields.ListItemDataOnMaps[indexItemData];
                m_GameLevelManagerFields.ListItemTileTutorials.Clear();
            }

            FloorGenerateItemTileDatas();
        }

        private void FloorGenerateItemTileDatas()
        {
            Debug.Log("FloorGenerateItemTileDatasFloorGenerateItemTileDatas");
            for (int i = 0; i < m_ListItemTileDatas.Count; i++)
            {
                global::Rush.Chocology.Gameplay.ItemTile itemTile = Instantiate(m_GameLevelManagerFields.ItemTilePrefab, m_GameLevelManagerFields.ListFloors[m_ListItemTileDatas[i].FloorIndex]);
                itemTile.InitTile(i, m_ListItemTileDatas[i].IndexOnMap, m_ListItemTileDatas[i].FloorIndex, m_ListItemTileDatas[i].PosTile, m_ListItemTileDatas[i].ItemData);
                itemTile.name = "" + i;
                //itemTile.gameObject.layer = LayerMask.NameToLayer("BG");
                StartCoroutine(PlaySoundMoveBoardStart(m_ListItemTileDatas[i].FloorIndex));
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial1())
                {
                    if (i >= m_ListItemTileDatas.Count - 3)
                    {
                        m_GameLevelManagerFields.ListItemTileTutorials.Add(itemTile);
                        itemTile.SetItemTileTut();
                    }
                }
            }

            StartCoroutine(SetStartLevelGaMEInternal());
        }

        public IEnumerator SetStartLevelGaME() => SetStartLevelGaMEInternal();
        private IEnumerator SetStartLevelGaMEInternal()
        {
            yield return new WaitForSeconds(m_GameLevelManagerFields.ListFloors.Count * 0.04f + 1.05f);
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetStartPlayingGame();
        }

        private int m_IndexMoveBoardStart = -1;
        private IEnumerator PlaySoundMoveBoardStart(int floorIndex)
        {
            yield return new WaitForSeconds(0.2f * floorIndex + 0.18f);
            if (floorIndex > m_IndexMoveBoardStart)
            {
                //Debug.Log("PlaySound_MoveBoardStartPlaySound_MoveBoardStartPlaySound_MoveBoardStartPlaySound_MoveBoardStart");
                m_IndexMoveBoardStart = floorIndex;
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundShowBoard();
            }
        }

        public global::Rush.Chocology.Gameplay.ItemTileSlot ItemTileSlotPrefab { get => m_GameLevelManagerFields.ItemTileSlotPrefab; set => m_GameLevelManagerFields.ItemTileSlotPrefab = value; }
        public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTileSlot> ListItemSlots { get => m_GameLevelManagerFields.ListItemSlots; set => m_GameLevelManagerFields.ListItemSlots = value; }
        public global::UnityEngine.Transform SlotParentTranform { get => m_GameLevelManagerFields.SlotParentTranform; set => m_GameLevelManagerFields.SlotParentTranform = value; }

        public void AddItemSlot(global::Rush.Chocology.Gameplay.ItemTile itemTile) => AddItemSlotInternal(itemTile);
        private void AddItemSlotInternal(global::Rush.Chocology.Gameplay.ItemTile itemTile)
        {
            if (m_GameLevelManagerFields.ListItemSlots.Count < 7)
            {
                //Test1
                int indexNewSlot = FindIndexAddItemTileSlotInternal(itemTile);
                //int curCountItemSlot = listItemSlots.Count;
                global::Rush.Chocology.Gameplay.ItemTileSlot itemTileSlot = Instantiate(m_GameLevelManagerFields.ItemTileSlotPrefab, m_GameLevelManagerFields.SlotParentTranform);
                itemTileSlot.transform.localPosition = new Vector3(-3 * global::Rush.Chocology.Gameplay.ItemTile.TileSize + indexNewSlot * global::Rush.Chocology.Gameplay.ItemTile.TileSize, 0f, 0f);
                itemTile.transform.parent = itemTileSlot.transform;
                //  itemTile.gameObject.layer = LayerMask.NameToLayer("BG");
                itemTileSlot.SetItemTile(itemTile);
                itemTile.SetMoveToSlot(indexNewSlot);
                m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Add(itemTileSlot);
                //Find indexAdd newItemSlot
                m_GameLevelManagerFields.ListItemSlots.Insert(indexNewSlot, itemTileSlot);
                StartCoroutine(SetListItemSlotResetPositionNowInternal());
            }

            if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial2())
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.ShowTut2();
            }
        }

        public int FindIndexAddItemTileSlot(global::Rush.Chocology.Gameplay.ItemTile itemTile) => FindIndexAddItemTileSlotInternal(itemTile);
        private int FindIndexAddItemTileSlotInternal(global::Rush.Chocology.Gameplay.ItemTile itemTile)
        {
            int indexSlot = m_GameLevelManagerFields.ListItemSlots.Count;
            for (int i = m_GameLevelManagerFields.ListItemSlots.Count - 1; i >= 0; i--)
            {
                if (m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData.ItemType == itemTile.ItemData.ItemType)
                {
                    return i + 1;
                }
            }

            return indexSlot;
        }

        private int m_CountWinVoice = 0;
        private int m_CountVoice = 0;
        public void SetMoveItemSlotFinished(global::Rush.Chocology.Gameplay.ItemTile _itemTile) => SetMoveItemSlotFinishedInternal(_itemTile);
        private void SetMoveItemSlotFinishedInternal(global::Rush.Chocology.Gameplay.ItemTile _itemTile)
        {
            //Debug.Log("SetMoveItemSlot_Finished");
            List<global::Rush.Chocology.Gameplay.ItemTileSlot> listCheckMatch3Slots = FindMatch3ItemTileSlotsInternal(_itemTile);
            if (listCheckMatch3Slots.Count == 3)
            {
                //playvoice
                //if (countWinVoice % 3 == 0)
                //{
                //    countWinVoice = 0;
                //    int voice = Random.Range(1, 3);
                //}
                //countWinVoice++;
                //  SoundManager.instance.PlaySound_Voice();
                //endplayvoice
                for (int i = 0; i < 3; i++)
                {
                    m_GameLevelManagerFields.ListItemSlots.Remove(listCheckMatch3Slots[i]);
                    //Undo
                    m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Remove(listCheckMatch3Slots[i]);
                    listCheckMatch3Slots[i].SetItemSlotMatch3();
                }

                StartCoroutine(SetListItemSlotResetPositionInternal());
                StartCoroutine(CheckGameWinInternal());
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundFreeBlock();
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetAddScore();
                global::Rush.Chocology.Economy.Config.Runtime.AddPiggyBankCoin();
            }
            else
            {
                //if (listItemSlots.Count == 4 || listItemSlots.Count == 6)
                //{
                //    countVoice = 0;
                //    int voice = Random.Range(3, 6);
                //}
                //countVoice++;
                //SoundManager.instance.PlaySound_Voice();
                StartCoroutine(CheckGameOverIEnumeratorInternal());
            }
        }

        public IEnumerator CheckGameOverIEnumerator() => CheckGameOverIEnumeratorInternal();
        private IEnumerator CheckGameOverIEnumeratorInternal()
        {
            if (!IsItemTileMoveToSlotInternal())
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundNoMoreMove();
            yield return new WaitForSeconds(1f);
            if (CheckGameOverInternal())
            {
                SetGameOverInternal();
            // Debug.Log("CHay vao day may len");
            }
        }

        public IEnumerator SetListItemSlotResetPosition() => SetListItemSlotResetPositionInternal();
        private IEnumerator SetListItemSlotResetPositionInternal()
        {
            //0.3 la thoi gian itemTile Efx Destroy
            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
            {
                m_GameLevelManagerFields.ListItemSlots[i].ResetPosSlot(i);
            }
        }

        public IEnumerator SetListItemSlotResetPositionNow() => SetListItemSlotResetPositionNowInternal();
        private IEnumerator SetListItemSlotResetPositionNowInternal()
        {
            //0.3 la thoi gian itemTile Efx Destroy
            yield return new WaitForSeconds(0.01f);
            for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
            {
                m_GameLevelManagerFields.ListItemSlots[i].ResetPosSlot(i);
            }
        }

        //Tim bo 3 voi itemTile vua dc chuyen den slot
        public List<global::Rush.Chocology.Gameplay.ItemTileSlot> FindMatch3ItemTileSlots(global::Rush.Chocology.Gameplay.ItemTile _itemTile) => FindMatch3ItemTileSlotsInternal(_itemTile);
        private List<global::Rush.Chocology.Gameplay.ItemTileSlot> FindMatch3ItemTileSlotsInternal(global::Rush.Chocology.Gameplay.ItemTile _itemTile)
        {
            List<global::Rush.Chocology.Gameplay.ItemTileSlot> listCheckMatch3_ItemTileSlot = new List<global::Rush.Chocology.Gameplay.ItemTileSlot>();
            for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
            {
                if (m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData.ItemType == _itemTile.ItemData.ItemType)
                {
                    listCheckMatch3_ItemTileSlot.Add(m_GameLevelManagerFields.ListItemSlots[i]);
                    if (listCheckMatch3_ItemTileSlot.Count == 3)
                    {
                        return listCheckMatch3_ItemTileSlot;
                    }
                }
            }

            return listCheckMatch3_ItemTileSlot;
        }

        public IEnumerator CheckGameWin() => CheckGameWinInternal();
        private IEnumerator CheckGameWinInternal()
        {
            bool isGameWin = CheckGameFinishedInternal();
            if (isGameWin)
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundClear();
            }

            yield return new WaitForSeconds(0.5f);
            if (isGameWin)
            {
                SetGameWinInternal();
            }
        }

        public bool CheckGameFinished() => CheckGameFinishedInternal();
        private bool CheckGameFinishedInternal()
        {
            for (int i = 0; i < m_GameLevelManagerFields.ListFloors.Count; i++)
            {
                if (m_GameLevelManagerFields.ListFloors[i].transform.childCount > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void SetGameWin() => SetGameWinInternal();
        private void SetGameWinInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountWin++;
            Debug.Log("COUNT WIN = " + global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountWin);
            if (global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountWin == 3)
            {
                global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountWin = 0;
                BspLabsAdsMobile.Instance.ShowInterstitial();
            }

            Debug.Log("Level Clear");
            global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.LevelClear();
            //Debug.LogError("GAME WIN");
            //PlayerPrefs.SetInt("CURREN_LEVEL", GamePlayManager.instance.level + 1);
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetGameWin();
        }

        public bool CheckGameOver() => CheckGameOverInternal();
        private bool CheckGameOverInternal()
        {
            if (m_GameLevelManagerFields.ListItemSlots.Count < 7)
            {
                return false;
            }

            for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
            {
                int countItem_ItemTile = CountItemTileSlotHaveItemDataInternal(m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData);
                if (countItem_ItemTile == 3)
                    return false;
            }

            return true;
        }

        public bool IsItemTileMoveToSlot() => IsItemTileMoveToSlotInternal();
        private bool IsItemTileMoveToSlotInternal()
        {
            if (m_GameLevelManagerFields.ListItemSlots.Count >= 7)
            {
                return false;
            }

            return true;
        }

        public void SetGameOver() => SetGameOverInternal();
        private void SetGameOverInternal()
        {
            //Debug.LogError("GAME OVER");
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetGameLose();
        }

        public IEnumerator ShowSlotBG() => ShowSlotBGInternal();
        private IEnumerator ShowSlotBGInternal()
        {
            //SoundManager.instance.PlaySound_ShowBoard();
            m_GameLevelManagerFields.SlotBG.transform.DOLocalMoveY(-5f, 0f);
            yield return new WaitForSeconds(0.5f);
            m_GameLevelManagerFields.SlotBG.gameObject.SetActive(true);
            m_GameLevelManagerFields.SlotBG.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutQuart);
        }

        public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTileSlot> ListCheckUndoItemTileSlots { get => m_GameLevelManagerFields.ListCheckUndoItemTileSlots; set => m_GameLevelManagerFields.ListCheckUndoItemTileSlots = value; }

        public bool CheckUndoAvaiable() => CheckUndoAvaiableInternal();
        private bool CheckUndoAvaiableInternal()
        {
            return m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Count > 0;
        }

        public void SetUndo() => SetUndoInternal();
        private void SetUndoInternal()
        {
            if (m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Count > 0)
            {
                global::Rush.Chocology.Gameplay.ItemTileSlot itemTileSlot_Undo = m_GameLevelManagerFields.ListCheckUndoItemTileSlots[m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Count - 1];
                itemTileSlot_Undo.ItemTile.transform.parent = m_GameLevelManagerFields.ListFloors[itemTileSlot_Undo.ItemTile.FloorIndex];
                //itemTileSlot_Undo.itemTile.SetTouch_Avaiable(true);
                itemTileSlot_Undo.ItemTile.SetItemTileUndo();
                m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Remove(itemTileSlot_Undo);
                m_GameLevelManagerFields.ListItemSlots.Remove(itemTileSlot_Undo);
                Destroy(itemTileSlot_Undo.gameObject);
                StartCoroutine(SetListItemSlotResetPositionNowInternal());
            }
        }

        public void SetUndoAll() => SetUndoAllInternal();
        private void SetUndoAllInternal()
        {
            for (int i = m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Count - 1; i >= 0; i--)
            {
                global::Rush.Chocology.Gameplay.ItemTileSlot itemTileSlot_Undo = m_GameLevelManagerFields.ListCheckUndoItemTileSlots[m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Count - 1];
                itemTileSlot_Undo.ItemTile.transform.parent = m_GameLevelManagerFields.ListFloors[itemTileSlot_Undo.ItemTile.FloorIndex];
                itemTileSlot_Undo.ItemTile.SetItemTileUndoNow();
                m_GameLevelManagerFields.ListCheckUndoItemTileSlots.Remove(itemTileSlot_Undo);
                m_GameLevelManagerFields.ListItemSlots.Remove(itemTileSlot_Undo);
                Destroy(itemTileSlot_Undo.gameObject);
            }
        }

        public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile> ListShuffleItemTiles { get => m_GameLevelManagerFields.ListShuffleItemTiles; set => m_GameLevelManagerFields.ListShuffleItemTiles = value; }

        public void SetShuffle() => SetShuffleInternal();
        private void SetShuffleInternal()
        {
            m_GameLevelManagerFields.ListShuffleItemTiles.Clear();
            for (int i = 0; i < m_GameLevelManagerFields.ListFloors.Count; i++)
            {
                foreach (Transform child in m_GameLevelManagerFields.ListFloors[i])
                {
                    global::Rush.Chocology.Gameplay.ItemTile itemTile = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.ItemTile>(child);
                    m_GameLevelManagerFields.ListShuffleItemTiles.Add(itemTile);
                }
            }

            List<global::Rush.Chocology.Gameplay.ItemTile> listShuffle_ItemTiles_Temp = new List<global::Rush.Chocology.Gameplay.ItemTile>(m_GameLevelManagerFields.ListShuffleItemTiles);
            List<global::Rush.Chocology.GameplayData.ItemData> listShuffle_ItemDatas = new List<global::Rush.Chocology.GameplayData.ItemData>();
            for (int i = 0; i < m_GameLevelManagerFields.ListShuffleItemTiles.Count; i++)
            {
                int index = Random.Range(0, listShuffle_ItemTiles_Temp.Count);
                listShuffle_ItemDatas.Add(listShuffle_ItemTiles_Temp[index].ItemData);
                listShuffle_ItemTiles_Temp.RemoveAt(index);
            }

            for (int i = 0; i < m_GameLevelManagerFields.ListShuffleItemTiles.Count; i++)
            {
                m_GameLevelManagerFields.ListShuffleItemTiles[i].SetItemTileShuffle(listShuffle_ItemDatas[i]);
            }
        }

        public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile> ListSuggestItemTiles { get => m_GameLevelManagerFields.ListSuggestItemTiles; set => m_GameLevelManagerFields.ListSuggestItemTiles = value; }

        private Dictionary<global::Rush.Chocology.Economy.Config.ITEM_TYPE, List<global::Rush.Chocology.Gameplay.ItemTile>> m_DicItemTiles = new Dictionary<global::Rush.Chocology.Economy.Config.ITEM_TYPE, List<global::Rush.Chocology.Gameplay.ItemTile>>();
        public global::System.Collections.Generic.Dictionary<global::Rush.Chocology.Economy.Config.ITEM_TYPE, global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile>> DicItemTiles { get => m_DicItemTiles; set => m_DicItemTiles = value; }

        private Dictionary<global::Rush.Chocology.Economy.Config.ITEM_TYPE, List<global::Rush.Chocology.Gameplay.ItemTile>> m_DicItemTilesAll = new Dictionary<global::Rush.Chocology.Economy.Config.ITEM_TYPE, List<global::Rush.Chocology.Gameplay.ItemTile>>();
        public global::System.Collections.Generic.Dictionary<global::Rush.Chocology.Economy.Config.ITEM_TYPE, global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile>> DicItemTilesAll { get => m_DicItemTilesAll; set => m_DicItemTilesAll = value; }

        public void SetSuggest() => SetSuggestInternal();
        private void SetSuggestInternal()
        {
            m_GameLevelManagerFields.ListSuggestItemTiles.Clear();
            for (int i = 0; i < m_GameLevelManagerFields.ListFloors.Count; i++)
            {
                foreach (Transform child in m_GameLevelManagerFields.ListFloors[i])
                {
                    global::Rush.Chocology.Gameplay.ItemTile itemTile = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.ItemTile>(child);
                    m_GameLevelManagerFields.ListSuggestItemTiles.Add(itemTile);
                }
            }

            Debug.Log("listSuggest_ItemTiles:" + m_GameLevelManagerFields.ListSuggestItemTiles.Count);
            SplitListSuggestItemTiles();
            List<global::Rush.Chocology.Gameplay.ItemTile> listItemTileSuggests = AiSuggestInternal();
            Debug.Log("listItemTileSuggests:" + listItemTileSuggests.Count);
            if (listItemTileSuggests.Count > 0)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetSuggestSuccess();
                StartCoroutine(SetSuggestIEnumerator(listItemTileSuggests));
            }
        }

        public bool CheckSuggestAvaiable() => CheckSuggestAvaiableInternal();
        private bool CheckSuggestAvaiableInternal()
        {
            m_GameLevelManagerFields.ListSuggestItemTiles.Clear();
            for (int i = 0; i < m_GameLevelManagerFields.ListFloors.Count; i++)
            {
                foreach (Transform child in m_GameLevelManagerFields.ListFloors[i])
                {
                    global::Rush.Chocology.Gameplay.ItemTile itemTile = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.ItemTile>(child);
                    m_GameLevelManagerFields.ListSuggestItemTiles.Add(itemTile);
                }
            }

            Debug.Log("listSuggest_ItemTiles:" + m_GameLevelManagerFields.ListSuggestItemTiles.Count);
            SplitListSuggestItemTiles();
            List<global::Rush.Chocology.Gameplay.ItemTile> listItemTileSuggests = AiSuggestInternal();
            Debug.Log("listItemTileSuggests:" + listItemTileSuggests.Count);
            if (listItemTileSuggests.Count > 0)
            {
                return true;
            }

            return false;
        }

        private IEnumerator SetSuggestIEnumerator(List<global::Rush.Chocology.Gameplay.ItemTile> listItemTileSuggests)
        {
            yield return new WaitForSeconds(0.02f);
            for (int i = 0; i < listItemTileSuggests.Count; i++)
            {
                listItemTileSuggests[i].SetItemTileSuggest();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void SplitListSuggestItemTiles()
        {
            List<global::Rush.Chocology.Gameplay.ItemTile> listTempSuggest_ItemTiles = new List<global::Rush.Chocology.Gameplay.ItemTile>(m_GameLevelManagerFields.ListSuggestItemTiles);
            m_DicItemTiles.Clear();
            m_DicItemTilesAll.Clear();
            for (int i = listTempSuggest_ItemTiles.Count - 1; i >= 0; i--)
            {
                if (listTempSuggest_ItemTiles[i].TouchAvaiable)
                {
                    if (m_DicItemTiles.ContainsKey(listTempSuggest_ItemTiles[i].ItemData.ItemType))
                    {
                        m_DicItemTiles[listTempSuggest_ItemTiles[i].ItemData.ItemType].Add(listTempSuggest_ItemTiles[i]);
                    }
                    else
                    {
                        m_DicItemTiles.Add(listTempSuggest_ItemTiles[i].ItemData.ItemType, new List<global::Rush.Chocology.Gameplay.ItemTile>() { listTempSuggest_ItemTiles[i] });
                    }
                }

                if (m_DicItemTilesAll.ContainsKey(listTempSuggest_ItemTiles[i].ItemData.ItemType))
                {
                    m_DicItemTilesAll[listTempSuggest_ItemTiles[i].ItemData.ItemType].Add(listTempSuggest_ItemTiles[i]);
                }
                else
                {
                    m_DicItemTilesAll.Add(listTempSuggest_ItemTiles[i].ItemData.ItemType, new List<global::Rush.Chocology.Gameplay.ItemTile>() { listTempSuggest_ItemTiles[i] });
                }
            }
        }

        private List<global::Rush.Chocology.Gameplay.ItemTile> m_ListItemTileItemTileSlotChecked = new List<global::Rush.Chocology.Gameplay.ItemTile>();
        public List<global::Rush.Chocology.Gameplay.ItemTile> AiSuggest() => AiSuggestInternal();
        private List<global::Rush.Chocology.Gameplay.ItemTile> AiSuggestInternal()
        {
            List<global::Rush.Chocology.Gameplay.ItemTile> listItemTile_AI_Suggest = new List<global::Rush.Chocology.Gameplay.ItemTile>();
            if (m_GameLevelManagerFields.ListItemSlots.Count > 0)
            {
                listItemTile_AI_Suggest.Clear();
                List<global::Rush.Chocology.GameplayData.ItemData> listItemData_Checked = new List<global::Rush.Chocology.GameplayData.ItemData>();
                for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
                {
                    global::Rush.Chocology.GameplayData.ItemData itemData = m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData;
                    if (listItemData_Checked.Contains(itemData))
                    {
                        break;
                    }

                    listItemData_Checked.Add(itemData);
                    int countItemData = CountItemTileSlotHaveItemDataInternal(itemData);
                    if (countItemData == 1)
                    {
                        if (m_GameLevelManagerFields.ListItemSlots.Count <= 5)
                        {
                            if (m_DicItemTiles.ContainsKey(itemData.ItemType))
                            {
                                List<global::Rush.Chocology.Gameplay.ItemTile> listItemTile_Have_ItemData = m_DicItemTiles[itemData.ItemType];
                                if (listItemTile_Have_ItemData.Count >= 2)
                                {
                                    listItemTile_AI_Suggest.Add(listItemTile_Have_ItemData[0]);
                                    listItemTile_AI_Suggest.Add(listItemTile_Have_ItemData[1]);
                                    return listItemTile_AI_Suggest;
                                }
                            }
                        }
                    }
                    else if (countItemData == 2)
                    {
                        if (m_GameLevelManagerFields.ListItemSlots.Count <= 6)
                        {
                            if (m_DicItemTiles.ContainsKey(itemData.ItemType))
                            {
                                List<global::Rush.Chocology.Gameplay.ItemTile> listItemTile_Have_ItemData = m_DicItemTiles[itemData.ItemType];
                                if (listItemTile_Have_ItemData.Count >= 1)
                                {
                                    listItemTile_AI_Suggest.Add(listItemTile_Have_ItemData[0]);
                                    return listItemTile_AI_Suggest;
                                }
                            }
                        }
                    }
                }
            }

            //Neu ko tim dc bo nao thich hop voi cac item trong slot
            //->>> Tim 1 bo 3 moi de cho vao slot voi dieu kien so itemslot hien tai nho hon hoac bang 4
            if (m_GameLevelManagerFields.ListItemSlots.Count <= 4)
            {
                foreach (KeyValuePair<global::Rush.Chocology.Economy.Config.ITEM_TYPE, List<global::Rush.Chocology.Gameplay.ItemTile>> kvp in m_DicItemTiles)
                {
                    if (kvp.Value.Count >= 3)
                    {
                        listItemTile_AI_Suggest.Add(kvp.Value[0]);
                        listItemTile_AI_Suggest.Add(kvp.Value[1]);
                        listItemTile_AI_Suggest.Add(kvp.Value[2]);
                        return listItemTile_AI_Suggest;
                    }
                }
            }
            else
            {
                //Neu so itemSlot lon hon 4
                //Neu số itemSlot >= 6
                if (m_GameLevelManagerFields.ListItemSlots.Count >= 6)
                {
                    //Duyet cac bo 2 cua itemslot ->Tim 1 item mo cho xuong
                    Debug.Log("Tim 1 item mo cho xuong");
                    List<global::Rush.Chocology.GameplayData.ItemData> listItemData_Checked = new List<global::Rush.Chocology.GameplayData.ItemData>();
                    for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
                    {
                        global::Rush.Chocology.GameplayData.ItemData itemData = m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData;
                        if (listItemData_Checked.Contains(itemData))
                        {
                            break;
                        }

                        listItemData_Checked.Add(itemData);
                        int countItemData = CountItemTileSlotHaveItemDataInternal(itemData);
                        if (countItemData == 2)
                        {
                            Debug.Log("countItemData == 2");
                            Debug.Log("itemData:" + itemData.ItemType.ToString());
                            //Tim 1 item o mo cho xuong item slot
                            List<global::Rush.Chocology.Gameplay.ItemTile> listItemTile_Have_ItemData = m_DicItemTilesAll[itemData.ItemType];
                            if (listItemTile_Have_ItemData.Count >= 1)
                            {
                                listItemTile_AI_Suggest.Add(listItemTile_Have_ItemData[listItemTile_Have_ItemData.Count - 1]);
                                return listItemTile_AI_Suggest;
                            }
                        }
                    }

                    //Nếu đang có 6 itemSlot mà ko tìm đc bộ 2 nào thì ko suggest đc
                    return listItemTile_AI_Suggest;
                }
                else
                {
                    //Kiem tra listItemSlot ==5 ko? Neu co tim 1 bo 2 item cả mờ và ko sáng cho xuống
                    for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
                    {
                        //Ko tìm dc bộ 2 nào thì chắc chắn 5 item này là 5 cái khác nhau
                        global::Rush.Chocology.GameplayData.ItemData itemData = m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData;
                        List<global::Rush.Chocology.Gameplay.ItemTile> listItemTile_Have_ItemData = m_DicItemTilesAll[itemData.ItemType];
                        if (listItemTile_Have_ItemData.Count >= 2)
                        {
                            listItemTile_AI_Suggest.Add(listItemTile_Have_ItemData[listItemTile_Have_ItemData.Count - 1]);
                            listItemTile_AI_Suggest.Add(listItemTile_Have_ItemData[listItemTile_Have_ItemData.Count - 2]);
                            return listItemTile_AI_Suggest;
                        }
                    }

                    return listItemTile_AI_Suggest;
                }
            }

            //Nếu vẫn ko tìm đc thì tìm 3 bộ cả sáng cả mờ cho xuống 
            //Với điều kiện là listItemSlot <=4
            if (m_GameLevelManagerFields.ListItemSlots.Count <= 4)
            {
                foreach (KeyValuePair<global::Rush.Chocology.Economy.Config.ITEM_TYPE, List<global::Rush.Chocology.Gameplay.ItemTile>> kvp in m_DicItemTilesAll)
                {
                    if (kvp.Value.Count >= 3)
                    {
                        listItemTile_AI_Suggest.Add(kvp.Value[0]);
                        listItemTile_AI_Suggest.Add(kvp.Value[1]);
                        listItemTile_AI_Suggest.Add(kvp.Value[2]);
                        return listItemTile_AI_Suggest;
                    }
                }
            }

            return listItemTile_AI_Suggest;
        }

        public int CountItemTileSlotHaveItemData(global::Rush.Chocology.GameplayData.ItemData itemData) => CountItemTileSlotHaveItemDataInternal(itemData);
        private int CountItemTileSlotHaveItemDataInternal(global::Rush.Chocology.GameplayData.ItemData itemData)
        {
            int countItemSlot_Have_ItemData = 0;
            for (int i = 0; i < m_GameLevelManagerFields.ListItemSlots.Count; i++)
            {
                if (m_GameLevelManagerFields.ListItemSlots[i].ItemTile.ItemData == itemData)
                {
                    countItemSlot_Have_ItemData++;
                }
            }

            return countItemSlot_Have_ItemData;
        }

        private global::Rush.Chocology.Gameplay.ItemTile Find1ItemTile(global::Rush.Chocology.Gameplay.ItemTile itemTile)
        {
            return FindItemTile(itemTile);
        }

        private List<global::Rush.Chocology.Gameplay.ItemTile> Find2ItemTile(global::Rush.Chocology.Gameplay.ItemTile itemTile)
        {
            List<global::Rush.Chocology.Gameplay.ItemTile> listTempSuggest_ItemTiles = new List<global::Rush.Chocology.Gameplay.ItemTile>(m_GameLevelManagerFields.ListSuggestItemTiles);
            List<global::Rush.Chocology.Gameplay.ItemTile> listResult_ItemTiles = new List<global::Rush.Chocology.Gameplay.ItemTile>();
            for (int i = listTempSuggest_ItemTiles.Count - 1; i >= 0; i--)
            {
                if (listTempSuggest_ItemTiles[i].TouchAvaiable)
                {
                    if (listTempSuggest_ItemTiles[i].ItemData.ItemType == itemTile.ItemData.ItemType)
                    {
                        listResult_ItemTiles.Add(itemTile);
                        if (listResult_ItemTiles.Count == 2)
                        {
                            return listResult_ItemTiles;
                        }
                    }
                }
            }

            return null;
        }

        //Tim 1 item tile co itemData giong itemTile hien tai
        private global::Rush.Chocology.Gameplay.ItemTile FindItemTile(global::Rush.Chocology.Gameplay.ItemTile itemTile)
        {
            for (int i = m_GameLevelManagerFields.ListSuggestItemTiles.Count - 1; i >= 0; i--)
            {
                if (m_GameLevelManagerFields.ListSuggestItemTiles[i].TouchAvaiable)
                {
                    if (m_GameLevelManagerFields.ListSuggestItemTiles[i].ItemData.ItemType == itemTile.ItemData.ItemType)
                    {
                        return itemTile;
                    }
                }
            }

            return null;
        }


        public void Revive() => ReviveInternal();
        private void ReviveInternal()
        {
            StartCoroutine(ReviveIEnumeratorInternal());
        }

        public IEnumerator ReviveIEnumerator() => ReviveIEnumeratorInternal();
        private IEnumerator ReviveIEnumeratorInternal()
        {
            yield return new WaitForSeconds(0.1f);
            SetUndoAllInternal();
            yield return new WaitForSeconds(0.1f);
            SetShuffleInternal();
        }

        public global::System.Collections.Generic.List<global::Rush.Chocology.Gameplay.ItemTile> ListItemTileTutorials { get => m_GameLevelManagerFields.ListItemTileTutorials; set => m_GameLevelManagerFields.ListItemTileTutorials = value; }
        public global::UnityEngine.GameObject HandGuild { get => m_GameLevelManagerFields.HandGuild; set => m_GameLevelManagerFields.HandGuild = value; }

        public void ShowTut1HandGuildFirst() => ShowTut1HandGuildFirstInternal();
        private void ShowTut1HandGuildFirstInternal()
        {
            //Debug.Log("ShowTut1_HandGuild_StartShowTut1_HandGuild_Start");
            if (m_GameLevelManagerFields.HandGuild == null)
            {
                m_GameLevelManagerFields.HandGuild = Instantiate(Resources.Load("HandGuide"), gameObject.transform) as GameObject;
            }

            //float posX = listItemTile_Tutorials[0].transform.position.x;
            //Debug.Log("posX:" + posX);
            //float posY = listItemTile_Tutorials[0].transform.position.y;
            //Debug.Log("posY:" + posY);
            //Debug.LogError("AAAAAAAAA");
            m_GameLevelManagerFields.HandGuild.transform.localPosition = new Vector3(1.2f, 1.2f, 0);
        }

        public void ShowTut1HandGuild() => ShowTut1HandGuildInternal();
        private void ShowTut1HandGuildInternal()
        {
            //Debug.Log("ShowTut1_HandGuildShowTut1_HandGuild");
            if (m_GameLevelManagerFields.HandGuild == null)
            {
                m_GameLevelManagerFields.HandGuild = Instantiate(Resources.Load("HandGuide"), gameObject.transform) as GameObject;
            }

            float posX = m_GameLevelManagerFields.ListItemTileTutorials[0].transform.position.x;
            //        Debug.Log("posX:"+ posX);
            float posY = m_GameLevelManagerFields.ListItemTileTutorials[0].transform.position.y;
            //      Debug.Log("posY:" + posY);
            //        Debug.LogError("AAAAAAAAA");
            m_GameLevelManagerFields.HandGuild.transform.position = new Vector3(posX, posY, 0);
        }

        public void SetNextTut1(global::Rush.Chocology.Gameplay.ItemTile itemTile) => SetNextTut1Internal(itemTile);
        private void SetNextTut1Internal(global::Rush.Chocology.Gameplay.ItemTile itemTile)
        {
            m_GameLevelManagerFields.ListItemTileTutorials.Remove(itemTile);
            if (m_GameLevelManagerFields.ListItemTileTutorials.Count > 0)
            {
                ShowTut1HandGuildInternal();
            }
            else
            {
                if (m_GameLevelManagerFields.HandGuild != null)
                    Destroy(m_GameLevelManagerFields.HandGuild);
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.HideTut1();
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.SpriteRenderer>(m_GameLevelManagerFields.SlotBG).sortingLayerName = "Default";
            }
        }

    }
}
