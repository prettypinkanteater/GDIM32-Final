using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _smack;
    [SerializeField] AudioSource _yay;
    [SerializeField] public AudioSource _sizzle;
    [SerializeField] AudioSource _knifeChop;
    [SerializeField] AudioSource _angelic;
    [SerializeField] AudioSource _door;

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
        //Debug.Log("Sizzling");
        if(Locator.Instance.gameController.fryCOOKED == false)
        {
           _sizzle.Play();
        }
        
    }

    private void SmackSound()
    {
        _smack.Play();
    }


    public void Yay()
    {
        _yay.Play();
    }

    public void Door()
    {
        Debug.Log("Slam");
        _door.Play();
    }

    public void Angelic()
    {
        _angelic.Play();
    }
}
