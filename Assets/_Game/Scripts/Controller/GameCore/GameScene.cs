using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class GameScene : Singleton<GameScene>
{

    // inspector
    [Header("Param")]
    public TurnData turnData;
    public MathData mathData;

    [Space(10)]
    public Question[] questions;
    public Answer[] answers;
    public float timeFinish;

    [Space(10)]
    public string goodAnswer;
    public int indexQuestion;
    public int indexResult;


    // private
    [Inject] ViewInGame _viewInGame;
    private Math _math = new Math();
    private int _level = 1;
    private float _timeRemain;


    #region UNITY
    // private void Start()
    // {
    //     CacheComponent();
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextTurn();
        }
    }
    #endregion



    public void InitScene()
    {
        _timeRemain = timeFinish;
        NextTurn();
    }


    public void NextTurn()
    {
        //prepare for the turn
        RandomQuestion();
        PickRandomQuestion();
        RandomAnswer();

        _viewInGame.StartCountTime(_timeRemain);
    }


    public void RandomQuestion()
    {
        // setup for the turn
        int rand = UnityEngine.Random.Range(0, 4);
        int level = turnData.level;
        string oper = _math.GetOperator(rand);

        switch (rand)
        {
            case 0: mathData = _math.GenerateOperaterAddition(level, oper, turnData); break; // +
            case 1: mathData = _math.GenerateOperaterSubtract(level, oper, turnData); break; // - 
            case 2: mathData = _math.GenerateOperaterMultiple(level, oper, turnData); break; // x
            case 3: mathData = _math.GenerateOperaterDivision(level, oper, turnData); break; // :
        }

        print($"{mathData.number1} {mathData._operator}  {mathData.number2} {mathData.result}");
        SetTextOnQuestion();
    }


    public void PickRandomQuestion()
    {
        indexQuestion = UnityEngine.Random.Range(0, 4);

        questions.ToList().ForEach(x => x.SetSelected(false));
        questions[indexQuestion].SetAnswer();
    }


    public void RandomAnswer()
    {
        answers.ToList().ForEach(x =>
        {
            var rand = UnityEngine.Random.Range(1, 100);
            x.SetValue(rand.ToString());
        });

        goodAnswer = questions[indexQuestion].value;
        indexResult = UnityEngine.Random.Range(0, 4);
        answers[indexResult].SetValue(goodAnswer);
    }


    public void AnswerTheQuestion(string result)
    {
        print($"goodAnswer {goodAnswer} result {result}");
        switch (string.Equals(goodAnswer, result))
        {
            case true: NotifyCorrectAnswer(); break;
            case false: NotifyWrongAnswer(); break;
        }
    }


    public void NotifyCorrectAnswer()
    {
        // play effect correct answer
        questions.ToList().ForEach(x => x.PlayEffectRight());
        answers.ToList().ForEach(x => x.PlayEffectRight());
        answers[indexResult].PlayCorrectAnimation();

        // update ui param
        _viewInGame.CancelCounting();
        _viewInGame.UpdateLevel(_level++);

        // update score
        ScoreMgr.Instance.UpdateScore(1);
        SoundMgr.Instance.PlaySFX(SoundMgr.SFX_PICK_RIGHT);

        // reset turn
        DG.Tweening.DOVirtual.DelayedCall(1f, () => { ResetTurn(); });
    }


    public void NotifyWrongAnswer()
    {
        _viewInGame.CancelCounting();

        answers.ToList().ForEach(x => x.PlayEffectWrong());
        SoundMgr.Instance.PlaySFX(SoundMgr.SFX_PICK_WRONG);
        DG.Tweening.DOVirtual.DelayedCall(1f, () => { GameMgr.Instance.GameOver(); });
    }


    public void ShowTimeOut()
    {
        _viewInGame.CancelCounting();

        answers.ToList().ForEach(x => x.PlayEffectWrong());
        SoundMgr.Instance.PlaySFX(SoundMgr.SFX_PICK_WRONG);
        DG.Tweening.DOVirtual.DelayedCall(1f, () => { GameMgr.Instance.GameOver(); });
    }



    public void ResetTurn()
    {
        answers.ToList().ForEach(x => x.RefeshTurn());
        questions.ToList().ForEach(x => x.RefeshTurn());

        NextTurn();
        if (_timeRemain >= 1.5f) _timeRemain -= .2f; 
    }



    private void SetTextOnQuestion()
    {
        questions[0].SetValue(mathData.number1.ToString()); // number 1
        questions[2].SetValue(mathData.number2.ToString()); // number 2
        questions[1].SetValue(mathData._operator.ToString()); // operator
        questions[3].SetValue(mathData.result.ToString()); // result
    }



    public void ResetGame()
    {
        _level = 1;
        _timeRemain = timeFinish;
        _viewInGame.ResetData();

        transform.DOKill();
        answers.ToList().ForEach(x => x.RefeshTurn());
        questions.ToList().ForEach(x => x.RefeshTurn());

        GameMgr.EVENT_RESET_INGAME?.Invoke();
        DOVirtual.DelayedCall(1f, () => { NextTurn(); });
    }



}
