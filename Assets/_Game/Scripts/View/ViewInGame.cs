using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : View
{


    [Header("[Setting]")]
    [SerializeField] private Text txtLevel;
    [SerializeField] private Slider sliderTimer;
    [SerializeField] private GameObject objLevel;


    // [private]
    private bool _countTime = false;



    #region  UNITY
    // private void Start()
    // {
    // }

    // private void Update()
    // {
    // }
    #endregion



    #region STATE
    public override void StartState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void EndState()
    {
    }
    #endregion



    public void StartCountTime(float value)
    {
        _countTime = false;
        CountingTime(value, () => { GameScene.Instance.ShowTimeOut(); });
    }


    public void CancelCounting()
    {
        _countTime = true;
        SoundMgr.StopSFX(SoundMgr.SFX_TIMECOUNT);
    }


    public async void CountingTime(float value, Action callback)
    {
        var playsound = false;
        var currentTimer = value;
        sliderTimer.maxValue = value;
        sliderTimer.value = value;

        // counting time
        while (currentTimer >= 0 && !_countTime)
        {
            currentTimer -= .01f;
            sliderTimer.value = currentTimer;
            if (currentTimer <= 2 && !playsound)
            {
                SoundMgr.PlaySFXOneShot(SoundMgr.SFX_TIMECOUNT);
                playsound = true;
            }

            await UniTask.Delay(System.TimeSpan.FromSeconds(0.01f));
        }

        // out of time - lose game 
        if (currentTimer < 0)
        {
            callback?.Invoke();
        }
    }


    public void UpdateLevel(int level)
    {
        PlayCorrectAnimation();
        txtLevel.text = $"{level}";
    }


    private void PlayCorrectAnimation()
    {
        objLevel.GetComponent<Image>().DOFade(0, 1);
        objLevel.transform.DOScale(Vector3.one * 0.75f, 1).SetEase(Ease.InOutQuad)
            .OnComplete(() =>
            {
                objLevel.transform.localScale = Vector3.one * 0.45f;
                objLevel.GetComponent<Image>().DOFade(1, 0);
            });
    }


    public void Reset()
    {
        _countTime = true;
        sliderTimer.value = 0;
        sliderTimer.maxValue = 0;

        txtLevel.text = "0";
        objLevel.transform.DOKill();
        objLevel.transform.localScale = Vector3.one * 0.45f;
        objLevel.GetComponent<Image>().DOFade(1, 0);
    }


    public void OnClickButtonMenu()
    {
        GameScene.Instance.ResetGame();
        GameMgr.Instance.SetState(GameState.Menu);
        SoundMgr.PlayMusic(SoundMgr.MUSIC_BACKGROUND);
    }



}
