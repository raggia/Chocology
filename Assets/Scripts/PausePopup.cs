using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePopup : MonoBehaviour
{
    public static PausePopup instance;
    [Header("Popup")]
    public GameObject popup;
    public BBUIButton btnContinue;
    public BBUIButton btnRestart;
    public BBUIButton btnHome;
    public BBUIButton btnLevelSelect;
    public Text txtLevel;
    [Header("LockGroup")]
    public GameObject lockGroup;
    public global::Rush.Chocology.LevelMap.LevelPopup levelPopup;
    enum STATE_CLOSEPOPUP
    {
        CONTINNUE,
        RESTART,
        HOME,
        LEVELSELECT
    }

    STATE_CLOSEPOPUP stateClosePopup = STATE_CLOSEPOPUP.CONTINNUE;
    // Start is called before the first frame update
    void Start()
    {
        btnContinue.OnPointerClickCallBack_Completed.AddListener(TouchContinue);
        btnRestart.OnPointerClickCallBack_Completed.AddListener(TouchRestart);
        btnHome.OnPointerClickCallBack_Completed.AddListener(TouchHome);
        btnLevelSelect.OnPointerClickCallBack_Completed.AddListener(TouchLevelSelect);
        popup.GetComponent<BBUIView>().HideBehavior.onCallback_Completed.AddListener(PopupHideView_Finished);
    }

    // Update is called once per frame
    void Update()
    {
    }

    int level = 1;
    public void OpenPausePopup(int _level)
    {
        global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountPause++;
        level = _level;
        gameObject.SetActive(true);
        InitViews();
    }

    private void InitViews()
    {
        global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
        lockGroup.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        btnContinue.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(true);
        btnHome.gameObject.SetActive(true);
        txtLevel.text = $"Level:{(level)}";
        InitViews_ShowView();
    }

    public void InitViews_ShowView()
    {
        Sequence sequenceShowView = DOTween.Sequence();
        sequenceShowView.InsertCallback(0.01f, () =>
        {
            popup.gameObject.SetActive(true);
            popup.GetComponent<BBUIView>().ShowView();
        });
    //sequenceShowView.InsertCallback(0.6f, () =>
    //{
    //    btnContinue.gameObject.SetActive(true);
    //    btnContinue.GetComponent<BBUIView>().ShowView();
    //});
    //sequenceShowView.InsertCallback(0.8f, () =>
    //{
    //    btnRestart.gameObject.SetActive(true);
    //    btnRestart.GetComponent<BBUIView>().ShowView();
    //});
    //sequenceShowView.InsertCallback(0.8f, () =>
    //{
    //    btnHome.gameObject.SetActive(true);
    //    btnHome.GetComponent<BBUIView>().ShowView();
    //});
    }

    public void TouchContinue()
    {
        stateClosePopup = STATE_CLOSEPOPUP.CONTINNUE;
        lockGroup.gameObject.SetActive(true);
        popup.GetComponent<BBUIView>().HideView();
    }

    public void TouchLevelSelect()
    {
        stateClosePopup = STATE_CLOSEPOPUP.LEVELSELECT;
        lockGroup.gameObject.SetActive(true);
        levelPopup.ShowLevelPopup();
        popup.GetComponent<BBUIView>().HideView();
    }

    public void TouchRestart()
    {
        {
            stateClosePopup = STATE_CLOSEPOPUP.RESTART;
            lockGroup.gameObject.SetActive(true);
            popup.GetComponent<BBUIView>().HideView();
        }
    }

    public void TouchHome()
    {
        stateClosePopup = STATE_CLOSEPOPUP.HOME;
        lockGroup.gameObject.SetActive(true);
        {
            popup.GetComponent<BBUIView>().HideView();
        }
    }

    private void PopupHideView_Finished()
    {
        if (stateClosePopup == STATE_CLOSEPOPUP.CONTINNUE)
        {
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUnPause();
        }
        else if (stateClosePopup == STATE_CLOSEPOPUP.RESTART)
        {
            SceneManager.LoadScene("Play");
        }
        else if (stateClosePopup == STATE_CLOSEPOPUP.HOME)
        {
            SceneManager.LoadScene("Menu");
        }

        gameObject.SetActive(false);
    }
}
