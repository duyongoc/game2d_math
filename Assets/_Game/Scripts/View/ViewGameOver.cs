using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : View
{


    [Header("[Setting]")]
    [SerializeField] private Text textScore;
    [SerializeField] private Text textHighScore;
    [SerializeField] private Transform highScorePanel;



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



    private void ShowScore()
    {
        int score = ScoreMgr.Instance.score;
        int highScore = ScoreMgr.Instance.highscore;
        var playfab = PlayfabController.Instance;

        textScore.text = score.ToString();
        textHighScore.text = $"Current score: {score.ToString()} \nHigh score: {playfab.HighScore}";
        playfab.CheckShowRecordScore(score);
        // textHighScore.text = highScore.ToString();
    }


    public void OnClickButtonReplay()
    {
        GameMgr.Instance.ReplayGame();
        SoundMgr.Instance.PlaySFX(SoundMgr.SFX_CLICK);
    }


    public void OnClickButtonMenu()
    {
        GameScene.Instance.ResetGame();
        GameMgr.Instance.SetState(GameState.Menu);
        SoundMgr.PlayMusic(SoundMgr.MUSIC_BACKGROUND);
    }


    public void OnClickButtonLeaderBoard()
    {
        PlayfabController.Instance.ShowLeaderBoard();
    }

}
