using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "StarGroup")]
    public class StarGroup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class StarGroupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("listStars")]
            [UnityEngine.SerializeField]
            private List<Image> m_ListStars = new List<Image>();
            public global::System.Collections.Generic.List<global::UnityEngine.UI.Image> ListStars { get => m_ListStars; set => m_ListStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spriteStar_Normal")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteStarNormal;
            public global::UnityEngine.Sprite SpriteStarNormal { get => m_SpriteStarNormal; set => m_SpriteStarNormal = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spriteStar_Dark")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteStarDark;
            public global::UnityEngine.Sprite SpriteStarDark { get => m_SpriteStarDark; set => m_SpriteStarDark = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("imgProgress")]
            [UnityEngine.SerializeField]
            private Image m_ImgProgress;
            public global::UnityEngine.UI.Image ImgProgress { get => m_ImgProgress; set => m_ImgProgress = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("score")]
            [UnityEngine.SerializeField]
            private float m_Score = 100f;
            public float Score { get => m_Score; set => m_Score = value; }
        }

        [global::UnityEngine.SerializeField]
        private StarGroupField m_StarGroupFields = new StarGroupField();
        public global::System.Collections.Generic.List<global::UnityEngine.UI.Image> ListStars { get => m_StarGroupFields.ListStars; set => m_StarGroupFields.ListStars = value; }
        public global::UnityEngine.Sprite SpriteStarNormal { get => m_StarGroupFields.SpriteStarNormal; set => m_StarGroupFields.SpriteStarNormal = value; }
        public global::UnityEngine.Sprite SpriteStarDark { get => m_StarGroupFields.SpriteStarDark; set => m_StarGroupFields.SpriteStarDark = value; }
        public global::UnityEngine.UI.Image ImgProgress { get => m_StarGroupFields.ImgProgress; set => m_StarGroupFields.ImgProgress = value; }

        private int m_CurrStar = 3;
        private const float c_ScoreMax = 100f;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial1())
                    return;
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial2())
                    return;
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial3())
                    return;
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial4())
                    return;
                m_CountDownTimeA += Time.deltaTime;
                //Debug.Log(countDownTimeA);
                if (m_IsCountDownTime)
                {
                    if (m_CountDownTimeA > m_ConfigLevelGame.TimeA)
                    {
                        m_StarGroupFields.Score -= global::Rush.Chocology.Gameplay.ConfigLevelGame.scoreInterval_Decrease * Time.deltaTime;
                        if (m_StarGroupFields.Score <= 0)
                        {
                            m_StarGroupFields.Score = 0;
                            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetGameLose();
                            m_IsCountDownTime = false;
                        }

                        UpdateScoreInternal();
                        UpdateStarInternal();
                    }
                }
            }
        }

        private bool m_IsCountDownTime = false;
        private global::Rush.Chocology.Gameplay.ConfigLevelGame m_ConfigLevelGame;
        public void InitStarGroup(global::Rush.Chocology.Gameplay.ConfigLevelGame _configLevelGame) => InitStarGroupInternal(_configLevelGame);
        private void InitStarGroupInternal(global::Rush.Chocology.Gameplay.ConfigLevelGame _configLevelGame)
        {
            m_ConfigLevelGame = _configLevelGame;
            m_StarGroupFields.Score = c_ScoreMax;
            m_IsCountDownTime = true;
            for (int i = 0; i < m_StarGroupFields.ListStars.Count; i++)
            {
                m_StarGroupFields.ListStars[i].rectTransform.anchoredPosition = new Vector2(-286.5f + m_ConfigLevelGame.ListScroreStars[i + 1] / 100f * 573f, 0f);
            }
        }

        public void ReviveInitStarGroup() => ReviveInitStarGroupInternal();
        private void ReviveInitStarGroupInternal()
        {
        //isCountDownTime = true;
        //score = SCORE_MAX;
        //currStar = 3;
        }

        private float m_CountDownTimeA;
        public float Score { get => m_StarGroupFields.Score; set => m_StarGroupFields.Score = value; }

        public void UpdateScore() => UpdateScoreInternal();
        private void UpdateScoreInternal()
        {
            m_StarGroupFields.ImgProgress.fillAmount = m_StarGroupFields.Score / 100f;
        }

        public void UpdateStar() => UpdateStarInternal();
        private void UpdateStarInternal()
        {
            if (Mathf.CeilToInt(m_StarGroupFields.Score) < m_ConfigLevelGame.ListScroreStars[m_CurrStar])
            {
                ChangeStarInternal();
            }
        }

        public void ChangeStar() => ChangeStarInternal();
        private void ChangeStarInternal()
        {
            m_CurrStar = m_CurrStar - 1;
            if (m_CurrStar >= 0)
            {
                Sequence sequenceChagneStar = DOTween.Sequence();
                sequenceChagneStar.Insert(0f, m_StarGroupFields.ListStars[m_CurrStar].transform.DOScale(0f, 0.1f).SetEase(Ease.OutQuad));
                sequenceChagneStar.Insert(0f, m_StarGroupFields.ListStars[m_CurrStar].transform.DORotate(new Vector3(0f, 0f, Random.Range(90f, 180f)), 0.1f).SetEase(Ease.OutQuad));
                sequenceChagneStar.InsertCallback(0.1f, () =>
                {
                    m_StarGroupFields.ListStars[m_CurrStar].sprite = m_StarGroupFields.SpriteStarDark;
                    m_StarGroupFields.ListStars[m_CurrStar].SetNativeSize();
                });
                sequenceChagneStar.Insert(0.15f, m_StarGroupFields.ListStars[m_CurrStar].transform.DORotate(Vector3.zero, 0.2f).SetEase(Ease.OutBounce));
                sequenceChagneStar.Insert(0.15f, m_StarGroupFields.ListStars[m_CurrStar].transform.DOScale(1f, 0.2f).SetEase(Ease.OutBounce));
            }
        }

        public void AddScore() => AddScoreInternal();
        private void AddScoreInternal()
        {
            if (m_IsCountDownTime)
            {
                m_CountDownTimeA = 0;
                m_StarGroupFields.Score += global::Rush.Chocology.Gameplay.ConfigLevelGame.scoreInterval_Increase;
                if (m_StarGroupFields.Score >= 100)
                {
                    m_StarGroupFields.Score = 100;
                }
                else if (m_CurrStar <= 2)
                {
                    if (m_StarGroupFields.Score >= m_ConfigLevelGame.ListScroreStars[m_CurrStar + 1])
                    {
                        m_StarGroupFields.Score = m_ConfigLevelGame.ListScroreStars[m_CurrStar + 1] - 0.01f;
                    }
                }

                DOTween.Kill(m_StarGroupFields.ImgProgress);
                m_StarGroupFields.ImgProgress.DOFillAmount(m_StarGroupFields.Score / 100f, 0.2f).SetEase(Ease.Linear);
            }
        }

        public int CurrStar
        {
            get
            {
                return m_CurrStar;
            }
        }
    }
}
