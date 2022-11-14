using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : View
{


    [Space(10)]
    [SerializeField] private Text textScore;

    [Space(10)]
    [SerializeField] private Text textHighScore;
    [SerializeField] private Transform highScorePanel;


    // private
    private bool _isDoneGameover;



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
        ShowScore();
    }

    public override void UpdateState()
    {
    }

    public override void EndState()
    {
    }
    #endregion




    public void OnClickButtonReplay()
    {
        GameMgr.Instance.ReplayGame();
        SoundMgr.Instance.PlaySFX(SoundMgr.SFX_CLICK);
    }


    private  void ShowScore()
    {
        int score = ScoreMgr.Instance.score;
        textScore.text = score.ToString();

        int highScore = ScoreMgr.Instance.highscore;
        textHighScore.text = highScore.ToString();
    }


}
