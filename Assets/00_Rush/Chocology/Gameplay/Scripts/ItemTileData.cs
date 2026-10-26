/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rush.Chocology.Gameplay
{
    [Serializable]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemTileData")]
    public class ItemTileData
    {
        [global::System.Serializable]
        private sealed class ItemTileDataField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("floorIndex")]
            [UnityEngine.SerializeField]
            private int m_FloorIndex;
            public int FloorIndex { get => m_FloorIndex; set => m_FloorIndex = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("posTile")]
            [UnityEngine.SerializeField]
            private Vector2Int m_PosTile;
            public global::UnityEngine.Vector2Int PosTile { get => m_PosTile; set => m_PosTile = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemData")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.GameplayData.ItemData m_ItemData;
            public global::Rush.Chocology.GameplayData.ItemData ItemData { get => m_ItemData; set => m_ItemData = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("indexOnMap")]
            [UnityEngine.SerializeField]
            private int m_IndexOnMap;
            public int IndexOnMap { get => m_IndexOnMap; set => m_IndexOnMap = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemTileDataField m_ItemTileDataFields = new ItemTileDataField();
        public int FloorIndex { get => m_ItemTileDataFields.FloorIndex; set => m_ItemTileDataFields.FloorIndex = value; }
        public global::UnityEngine.Vector2Int PosTile { get => m_ItemTileDataFields.PosTile; set => m_ItemTileDataFields.PosTile = value; }
        public global::Rush.Chocology.GameplayData.ItemData ItemData { get => m_ItemTileDataFields.ItemData; set => m_ItemTileDataFields.ItemData = value; }
        public int IndexOnMap { get => m_ItemTileDataFields.IndexOnMap; set => m_ItemTileDataFields.IndexOnMap = value; }

        public ItemTileData()
        {
        }

        public ItemTileData(int _floorIndex, int _indexOnMap, Vector2Int _posTile)
        {
            m_ItemTileDataFields.FloorIndex = _floorIndex;
            m_ItemTileDataFields.IndexOnMap = _indexOnMap;
            m_ItemTileDataFields.PosTile = _posTile;
        }
    }
}
