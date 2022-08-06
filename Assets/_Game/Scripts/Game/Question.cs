using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    [Space(10)]
    public Image imgQuestion;
    public Text txtQuestion;
    public float timeEffect = 1.2f;

    [Space(10)]
    public GameObject objSelected;


    public string value;


    #region UNITY
    // private void Start()
    // {
    // }

    // private void Update()
    // {
    // }
    #endregion



    public void SetSelected(bool value)
    {
        objSelected.SetActive(value);
    }


    public void SetValue(string newValue)
    {
        value = newValue;
        txtQuestion.text = value;
    }


    public void SetAnswer()
    {
        objSelected.SetActive(true);
        txtQuestion.text = "?";
    }


    public void PlayEffectRight()
    {
        transform.DOScale(Vector3.one * 1.1f, timeEffect * 2);

        Sequence effectSq = DOTween.Sequence();
        effectSq
                // .Append(transform.DOScale(Vector3.one * 1.25f, timeEffect))
                .Append(txtQuestion.DOFade(0, timeEffect))
                .Append(imgQuestion.DOFade(0, timeEffect))
                .OnComplete(() =>
                {
                    transform.DOKill();
                    transform.localScale = Vector3.one;
                });
    }


    public void RefeshTurn()
    {
        SetSelected(false);
        transform.DOKill();
        
        imgQuestion.DOFade(1, 0);
        txtQuestion.DOFade(1, 0);
        transform.localScale = Vector3.one;
    }

}
