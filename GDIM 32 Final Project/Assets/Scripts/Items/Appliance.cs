using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Appliance : Item
{
    [SerializeField] private float _cookingTimer;
    [SerializeField] private float _cookingTime = 10.0f;
    

    [SerializeField] Canvas _timerCanvas;
    private TMP_Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _cookingTimer = _cookingTime;
        _timerText = _timerCanvas.GetComponentInChildren<TMP_Text>();
        //Locator.Instance.player.Chop += TimmyReady;
    }

    private void OnEnable()
    {
        _cookingTimer = _cookingTime;
    }

    // Update is called once per frame
    void Update()
    {

        //if(Locator.Instance.gameController.burgerInProgress && this.gameObject.name == "Griller")
        //{
            //_timerCanvas.enabled = true;
        //}
        if(Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasItem && Locator.Instance.gameController.hasIngredient)
        {
            GameObject.Find("Timmy Tray").tag = "appliance";
        }

        if(Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasIngredient && Locator.Instance.gameController.hasItem)
        {
            GameObject.Find("Griller").layer = 0;
        }
        if (_cookingTimer <= 0f && Locator.Instance.gameController.placedIngredient)
        {
            
            //_cookingTimer = _cookingTime;
            if (Locator.Instance.gameController.burgerInProgress)
            {
                //_cookingTimer = _cookingTime;
                //changeCanvas();
               
                burgerDone();
                
            }
            if(Locator.Instance.gameController.fryInProgress)
            {
                changeCanvas();
                TimmyReady();
                FriesDone();
                //_cookingTimer = _cookingTime;
            }
            
            

        }

        if ((this.gameObject.name == "Frier" || this.gameObject.name == "Griller") &&
            ((Locator.Instance.gameController.placedIngredient && Locator.Instance.gameController.fryInProgress && Locator.Instance.gameController.cutPotato) || 
            (Locator.Instance.gameController.placedIngredient && Locator.Instance.gameController.burgerInProgress)))
        {
            if(Locator.Instance.gameController.burgerInProgress)
            {
                _timerText.enabled = true;
            }
            _cookingTimer -= Time.deltaTime;
            int _cookingTimerInt = (int)_cookingTimer;

                this._timerText.text = _cookingTimerInt.ToString();
            
        }
        if (this.gameObject.name == "Cutting Board" && Locator.Instance.gameController.cutPotato)         
        {
            GetComponent<Collider>().enabled = false;
        }
        if (this.gameObject.name == "Frier" && Locator.Instance.gameController.fryCOOKED)
        {
            gameObject.tag = "Untagged";
        }
        if(this.gameObject.name == "Griller" && Locator.Instance.gameController.hasIngredient && Locator.Instance.gameController.burgerInProgress && !Locator.Instance.gameController.hasItem)
        {
            this.gameObject.layer = 8;
        }

    }

    protected override void PickUp()
    {
        
    }

    protected override void PutDown()
    {
        
    }

    private void changeCanvas()
    {
        Debug.Log("Change Canvas");
        _timerCanvas.transform.localPosition = new Vector3(1.368f, 1.334f, -0.3299999f);
    }

    private void TimmyReady()
    {
        GameObject.Find("Timmy Tray").tag = "appliance";
    }

    private void resetTimmy()
    {
        GameObject.Find("Timmy Tray").tag = "Untagged";
    }

    private void FriesDone()
    {
        Debug.Log("FriesdDone");
        Locator.Instance.gameController.fryCOOKED = true;
        _timerText.enabled = false;
        Locator.Instance.gameController.ResetPickup();
        gameObject.layer = 0;
        GameObject.Find("Frier").layer = 0;
        _cookingTimer = _cookingTime;
        GameObject.Find("Griller").GetComponent<Appliance>().enabled = true;
        GameObject.Find("Frier").GetComponent<Appliance>().enabled = false;
    }

    private void burgerDone()
    {
        Debug.Log("Burger Done");
        Locator.Instance.gameController.fryCOOKED = true;
        Locator.Instance.gameController.burgerFlipped = true;
        _timerText.enabled = false;
        Locator.Instance.gameController.ResetPickup();
        //Locator.Instance.gameController.placedIngredient = true;
        //gameObject.layer = 0;
    }


}
