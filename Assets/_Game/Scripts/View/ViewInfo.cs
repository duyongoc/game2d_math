using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewInfo : View
{

    [Header("[Setting]")]
    public TMP_Text txtInfo;

    // [private]
    private System.Action callbackContinue;


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



    public void ShowInfo(string content, System.Action callback)
    {
        gameObject.SetActive(true);
        txtInfo.text = content;
        callbackContinue = callback;
    }


    public void OnClickButtonContinue()
    {
        callbackContinue?.Invoke();
        gameObject.SetActive(false);
    }


}
