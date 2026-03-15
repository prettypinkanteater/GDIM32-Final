using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _smack;
    [SerializeField] AudioSource _yay;
    [SerializeField] AudioSource _sadViolin;
    [SerializeField] public AudioSource _sizzle;
    [SerializeField] AudioSource _knifeChop;

    void Start()
    {
        Locator.Instance.player.ChopAnim += ChopSound;
        Locator.Instance.player.putDownEvent += SmackSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Locator.Instance.gameController.cutPotato || (Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.fryCOOKED && Locator.Instance.gameController.hasIngredient))
        {
            _knifeChop.Stop();
        }

        if (Locator.Instance.gameController.cutPotato && Locator.Instance.gameController.placedIngredient)
        {
            SizzleSound();
        }

        if (Locator.Instance.gameController.WhallyTime)
        {
            Yay();
        }
    }

    private void ChopSound()
    {
        if (Locator.Instance.gameController.fryInProgress)
        {
            _knifeChop.Play();
        }
    
    }

    public void SizzleSound()
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

    private void Yay()
    {
        _yay.Play();
    }
}
