using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    protected override void PickUp()
    {
        if(Locator.Instance.gameController.hasItem == false)
        {
            base.PickUp();
            Locator.Instance.gameController.hasIngredient = true;
        }
    }

    protected override void PutDown()
    {
        if(Locator.Instance.gameController.hasIngredient == true) 
        {

        }
    }

    //add putdown method override
}
