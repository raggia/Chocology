/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemTileCheckCollision")]
    public class ItemTileCheckCollision : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemTileCheckCollisionField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("itemTile")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.ItemTile m_ItemTile;
            public global::Rush.Chocology.Gameplay.ItemTile ItemTile { get => m_ItemTile; set => m_ItemTile = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("countCollision")]
            [UnityEngine.SerializeField]
            private int m_CountCollision = 0;
            public int CountCollision { get => m_CountCollision; set => m_CountCollision = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listCollisionObjecs")]
            [UnityEngine.SerializeField]
            private List<GameObject> m_ListCollisionObjecs = new List<GameObject>();
            public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListCollisionObjecs { get => m_ListCollisionObjecs; set => m_ListCollisionObjecs = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemTileCheckCollisionField m_ItemTileCheckCollisionFields = new ItemTileCheckCollisionField();
        public global::Rush.Chocology.Gameplay.ItemTile ItemTile { get => m_ItemTileCheckCollisionFields.ItemTile; set => m_ItemTileCheckCollisionFields.ItemTile = value; }
        public int CountCollision { get => m_ItemTileCheckCollisionFields.CountCollision; set => m_ItemTileCheckCollisionFields.CountCollision = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListCollisionObjecs { get => m_ItemTileCheckCollisionFields.ListCollisionObjecs; set => m_ItemTileCheckCollisionFields.ListCollisionObjecs = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_ItemTileCheckCollisionFields.CountCollision = 0;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("OnTriggerEnter2D:"+ collision.tag);
            if (collision.CompareTag("TileCheckCollision"))
            {
                if (m_ItemTileCheckCollisionFields.ItemTile.ItemTileState == global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR)
                {
                    if (global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.ItemTileCheckCollision>(collision).ItemTile.FloorIndex > m_ItemTileCheckCollisionFields.ItemTile.FloorIndex)
                    {
                        m_ItemTileCheckCollisionFields.ListCollisionObjecs.Add(collision.gameObject);
                        m_ItemTileCheckCollisionFields.CountCollision++;
                        m_ItemTileCheckCollisionFields.ItemTile.SetTouchAvaiable(false);
                        m_ItemTileCheckCollisionFields.ItemTile.SetShadowAvaiable(true);
                    }
                }
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("TileCheckCollision"))
            {
                if (m_ItemTileCheckCollisionFields.ItemTile.ItemTileState == global::Rush.Chocology.Economy.Config.ITEMTILE_STATE.FLOOR)
                {
                    if (global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.ItemTileCheckCollision>(collision).ItemTile.FloorIndex > m_ItemTileCheckCollisionFields.ItemTile.FloorIndex)
                    {
                        m_ItemTileCheckCollisionFields.CountCollision--;
                    }

                    if (m_ItemTileCheckCollisionFields.CountCollision <= 0)
                    {
                        //Debug.Log("OnTriggerExit2DOnTriggerExit2D:"+ itemTile.gameObject.name);
                        m_ItemTileCheckCollisionFields.ItemTile.SetTouchEnable();
                    //itemTile.SetShadow_Avaiable(false);
                    }
                }
            }
        }

        public void ResetCollisionCount() => ResetCollisionCountInternal();
        private void ResetCollisionCountInternal()
        {
            m_ItemTileCheckCollisionFields.CountCollision = 0;
        }
    }
}
