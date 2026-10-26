using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.Presentation
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "MouseCustom")]
    public class MouseCustom : MonoBehaviour
    {
        private SpriteRenderer m_Mouse;
        void Start()
        {
            m_Mouse = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.SpriteRenderer>(this);
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 customPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(customPos.x + 0.4f, customPos.y - 0.4f);
        }
    }
}
