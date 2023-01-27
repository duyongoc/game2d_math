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
        Load();
    }

    public override void UpdateState()
    {
    }

    public override void EndState()
    {
    }
    #endregion



    private void Load()
    {
        int score = ScoreManager.Instance.Score;
        int highScore = ScoreManager.Instance.Highscore;
        var playfab = PlayfabController.Instance;

        textScore.text = score.ToString();
        textHighScore.text = $"Best: {playfab.HighScore}";
        playfab.CheckShowRecordScore(score);
    }


    public void OnClickButtonReplay()
    {
        GameManager.Instance.ReplayGame();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_CLICK);
    }


    public void OnClickButtonMenu()
    {
        GameManager.Instance.SetState(GameState.Menu);
        SoundManager.PlayMusic(SoundManager.MUSIC_BACKGROUND);
    }


    public void OnClickButtonLeaderBoard()
    {
        PlayfabController.Instance.ShowLeaderBoard();
    }

}
