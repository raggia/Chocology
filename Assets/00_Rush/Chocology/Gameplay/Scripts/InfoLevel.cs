using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rush.Chocology.Gameplay
{
    [Serializable]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "InfoLevel")]
    public class InfoLevel
    {
        [UnityEngine.Serialization.FormerlySerializedAs("level")]
        [UnityEngine.SerializeField]
        private int m_Level;
        public int Level { get => m_Level; set => m_Level = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("star")]
        [UnityEngine.SerializeField]
        private int m_Star;
        public int Star { get => m_Star; set => m_Star = value; }

        public InfoLevel()
        {
        }

        public InfoLevel(int _level, int _star)
        {
            m_Level = _level;
            m_Star = _star;
        }
    }
}
