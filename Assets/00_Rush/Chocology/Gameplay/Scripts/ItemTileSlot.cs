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

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemTileSlot")]
    public class ItemTileSlot : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("itemTile")]
        [UnityEngine.SerializeField]
        [HideInInspector]
        private global::Rush.Chocology.Gameplay.ItemTile m_ItemTile;
        public global::Rush.Chocology.Gameplay.ItemTile ItemTile { get => m_ItemTile; set => m_ItemTile = value; }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SetItemTile(global::Rush.Chocology.Gameplay.ItemTile _itemTile) => SetItemTileInternal(_itemTile);
        private void SetItemTileInternal(global::Rush.Chocology.Gameplay.ItemTile _itemTile)
        {
            m_ItemTile = _itemTile;
        }

        public void SetItemSlotMatch3() => SetItemSlotMatch3Internal();
        private void SetItemSlotMatch3Internal()
        {
            m_ItemTile.SetItemTileMatch3(() =>
            {
                ItemTileSlotMatch3CallBackInternal();
            });
        }

        public void ItemTileSlotMatch3CallBack() => ItemTileSlotMatch3CallBackInternal();
        private void ItemTileSlotMatch3CallBackInternal()
        {
            Destroy(gameObject);
        }

        public void ItemTileSlotResetPos(int pos) => ItemTileSlotResetPosInternal(pos);
        private void ItemTileSlotResetPosInternal(int pos)
        {
        }

        private Sequence m_MoveResetPosSlotSequence;
        public void ResetPosSlot(int indexSlot) => ResetPosSlotInternal(indexSlot);
        private void ResetPosSlotInternal(int indexSlot)
        {
            m_ItemTile.ResetPosSlot(indexSlot);
            DOTween.Kill(gameObject.transform);
            m_MoveResetPosSlotSequence = DOTween.Sequence();
            m_MoveResetPosSlotSequence.Insert(0f, gameObject.transform.DOLocalMove(new Vector3(-3 * global::Rush.Chocology.Gameplay.ItemTile.TileSize + indexSlot * global::Rush.Chocology.Gameplay.ItemTile.TileSize, 0f, 0f), 0.2f).SetEase(Ease.OutQuad));
        }
    }
}
