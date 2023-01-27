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
    private bool _playsound = false;
    private float _currentTimer = -1;



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
        print("StartCountTime");
        _countTime = false;
        CountingTime(value);
    }


    public void CancelCounting()
    {
        _countTime = true;
        SoundManager.StopSFX(SoundManager.SFX_TIMECOUNT);
    }


    public async void CountingTime(float value)
    {
        _playsound = false;
        _currentTimer = value;
        sliderTimer.maxValue = value;
        sliderTimer.value = value;

        // counting time
        while (_currentTimer >= 0 && !_countTime)
        {
            // print("counting " + currentTimer);
            _currentTimer -= .01f;
            sliderTimer.value = _currentTimer;
            if (_currentTimer <= 2 && !_playsound)
            {
                SoundManager.PlaySFXOneShot(SoundManager.SFX_TIMECOUNT);
                _playsound = true;
            }

            await UniTask.Delay(System.TimeSpan.FromSeconds(0.01f));
        }

        // out of time - lose game 
        if (_currentTimer < 0)
        {
            GameScene.Instance.ShowTimeOut();
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
        print("Reset");
        _countTime = true;
        _currentTimer = -1;
        sliderTimer.value = 0;
        sliderTimer.maxValue = 0;

        txtLevel.text = "0";
        objLevel.transform.DOKill();
        objLevel.transform.localScale = Vector3.one * 0.45f;
        objLevel.GetComponent<Image>().DOFade(1, 0);
    }


    public void OnClickButtonMenu()
    {
        GameScene.Instance.Reset();
        GameManager.Instance.SetState(GameState.Menu);
        SoundManager.PlayMusic(SoundManager.MUSIC_BACKGROUND);
    }



}
