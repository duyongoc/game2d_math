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


    // inspector
    [Header("Text")]
    [SerializeField] private Text txtLevel;
    [SerializeField] private GameObject objLevel;

    [Space(10)]
    [SerializeField] private Slider sliderTimer;



    // private
    private bool _cancelCounting = false;



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
        base.StartState();
        StartView();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        UpdateView();
    }

    public override void EndState()
    {
        base.EndState();
        EndView();
    }
    #endregion



    private void StartView()
    {
    }

    private void UpdateView()
    {
    }

    private void EndView()
    {
    }



    public void StartCountTime(float value)
    {
        _cancelCounting = false;
        CountingTime(value, () => { GameScene.Instance.ShowTimeOut(); });
    }


    public void CancelCounting()
    {
        _cancelCounting = true;
        SoundMgr.StopSFX(SoundMgr.SFX_TIMECOUNT);
    }


    public async void CountingTime(float value, Action callback)
    {
        float currentTimer = value;
        sliderTimer.maxValue = value;
        sliderTimer.value = value;
        bool playsound = false;

        while (currentTimer >= 0 && !_cancelCounting)
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


    public void UpdateWrongText(int wrong)
    {
        // PlayWrongAnimation();
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


    public void ResetData()
    {
        txtLevel.text = "0";
        objLevel.transform.DOKill();
        objLevel.transform.localScale = Vector3.one * 0.45f;
        objLevel.GetComponent<Image>().DOFade(1, 0);
    }


}
