using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundy : MonoBehaviour
{

    [Header("[Setting]")]
    [SerializeField] private AudioSource audioSource;


    #region UNITY
    // private void Start()
    // {
    // }

    // private void Update()
    // {
    // }
    #endregion



    public void Play(AudioClip audi)
    {
        gameObject.name = audi.name;
        audioSource.clip = audi;
        audioSource.Play();
        SelfDestroy();
    }


    private void SelfDestroy()
    {
        var time = audioSource.clip.length * 2;
        Destroy(gameObject, time);
    }

}
