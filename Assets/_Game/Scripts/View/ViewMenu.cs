using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMenu : View
{



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



    public void OnClickButtonPlay()
    {
        GameManager.Instance.PlayGame();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_CLICK);
    }


    public void OnClickedLeaderBoard()
    {
        PlayfabController.Instance.ShowLeaderBoard();
    }


}
