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
        Locator.Instance.player.ChopAnim += ChopSound;
        Locator.Instance.player.IngredientUsed += SmackSound;
    }

    // Update is called once per frame
    void Update()
    {
        
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
