using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _smack;
    [SerializeField] AudioSource _yay;
    [SerializeField] AudioSource _sadViolin;
    [SerializeField] AudioSource _sizzle;
    [SerializeField] AudioSource _knifeChop;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Locator.Instance.gameController.cutPotato && Locator.Instance.gameController.fryInProgress)
        {
            ChopSound();
        }
    }

    private void ChopSound()
    {
        _knifeChop.Play();
    }

    private void SizzleSound()
    {
        _sizzle.Play();
    }

    private void SmackSound()
    {
        _smack.Play();
    }

    private void TimmySound()
    {
        _sadViolin.Play();
    }
}
