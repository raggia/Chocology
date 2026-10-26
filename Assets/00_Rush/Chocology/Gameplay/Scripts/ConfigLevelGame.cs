using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rush.Chocology.Gameplay
{
    [Serializable]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ConfigLevelGame")]
    public class ConfigLevelGame
    {
        [global::System.Serializable]
        private sealed class ConfigLevelGameField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("timeA")]
            [UnityEngine.SerializeField]
            [Tooltip("Mỗi A giây thì điểm bắt đầu giảm ( giá trị mặc định của A là 5)")]
            private float m_TimeA = 5f;
            public float TimeA { get => m_TimeA; set => m_TimeA = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("timercountdown")]
            [UnityEngine.SerializeField]
            private float m_Timercountdown = 10f;
            public float Timercountdown { get => m_Timercountdown; set => m_Timercountdown = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listScrore_Stars")]
            [UnityEngine.SerializeField]
            private List<float> m_ListScroreStars = new List<float>
            {
                0f,
                25f,
                50f,
                75f
            };
            public global::System.Collections.Generic.List<float> ListScroreStars { get => m_ListScroreStars; set => m_ListScroreStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listRewards_CoinValue")]
            [UnityEngine.SerializeField]
            [Tooltip("1sao - 10vang,2sao-12vang,3sao-15vang")]
            private List<int> m_ListRewardsCoinValue = new List<int>
            {
                2,
                1,
                2,
                3
            };
            public global::System.Collections.Generic.List<int> ListRewardsCoinValue { get => m_ListRewardsCoinValue; set => m_ListRewardsCoinValue = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listXReward_Value")]
            [UnityEngine.SerializeField]
            [Tooltip("xem video để được xReward")]
            private List<int> m_ListXRewardValue = new List<int>()
            {
                2,
                3,
                4,
                5
            };
            public global::System.Collections.Generic.List<int> ListXRewardValue { get => m_ListXRewardValue; set => m_ListXRewardValue = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listXReward_Percent")]
            [UnityEngine.SerializeField]
            private List<int> m_ListXRewardPercent = new List<int>()
            {
                50,
                20,
                20,
                10
            };
            public global::System.Collections.Generic.List<int> ListXRewardPercent { get => m_ListXRewardPercent; set => m_ListXRewardPercent = value; }
        }

        [global::UnityEngine.SerializeField]
        private ConfigLevelGameField m_ConfigLevelGameFields = new ConfigLevelGameField();
        public float TimeA { get => m_ConfigLevelGameFields.TimeA; set => m_ConfigLevelGameFields.TimeA = value; }
        public float Timercountdown { get => m_ConfigLevelGameFields.Timercountdown; set => m_ConfigLevelGameFields.Timercountdown = value; }

        // Khi điểm giảm, mỗi 1s sẽ giảm X điểm (giá trị mặc định của X là 1)
        public const float scoreInterval_Decrease = 1f;
        // Khi người chơi đưa được 01 tile xuống sàn sẽ tăng Y điểm, Y mặc định là 2
        public const float scoreInterval_Increase = 3f;
        public global::System.Collections.Generic.List<float> ListScroreStars { get => m_ConfigLevelGameFields.ListScroreStars; set => m_ConfigLevelGameFields.ListScroreStars = value; }
        public global::System.Collections.Generic.List<int> ListRewardsCoinValue { get => m_ConfigLevelGameFields.ListRewardsCoinValue; set => m_ConfigLevelGameFields.ListRewardsCoinValue = value; }
        public global::System.Collections.Generic.List<int> ListXRewardValue { get => m_ConfigLevelGameFields.ListXRewardValue; set => m_ConfigLevelGameFields.ListXRewardValue = value; }
        public global::System.Collections.Generic.List<int> ListXRewardPercent { get => m_ConfigLevelGameFields.ListXRewardPercent; set => m_ConfigLevelGameFields.ListXRewardPercent = value; }
    }
}
