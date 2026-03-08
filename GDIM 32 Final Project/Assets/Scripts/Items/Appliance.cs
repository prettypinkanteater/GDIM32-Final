using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance : Item
{
    private float _cookingTimer;
    private float _cookingTime = 10.0f;

    private delegate void TimerFinished();
    private event TimerFinished FoodDone; 

    // Start is called before the first frame update
    void Start()
    {
        _cookingTimer = _cookingTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (_cookingTimer <= 0f && Locator.Instance.gameController.placedIngredient)
        {
            // FoodDone.Invoke();
            // make sure to make placedingredient false when you remove it
            _cookingTimer = _cookingTime;
        }

        if (Locator.Instance.gameController.placedIngredient)
        {
            GetComponent<Collider>().enabled = false;
            _cookingTimer -= Time.deltaTime;
        }
        if (Locator.Instance.gameController.cutPotato)         
        {
            GetComponent<Collider>().enabled = true;
        }

    }

    protected override void PickUp()
    {
        
    }

    protected override void PutDown()
    {
        
    }
}
