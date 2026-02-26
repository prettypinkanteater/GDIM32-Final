using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.player.putDownEvent += PutDown;
        Locator.Instance.player.ItemUsed += PickUp;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    protected override void PickUp()
    {
        if(Locator.Instance.gameController.hasItem == false && Locator.Instance.gameController.placedIngredient == false)
        {
            base.PickUp();
            Locator.Instance.gameController.hasIngredient = true;
        }
    }

    protected override void PutDown()
    {
        if(Locator.Instance.gameController.hasIngredient == true) 
        {
            base.PutDown();
            transform.SetParent(Locator.Instance.player.lookingAt.transform);
            Locator.Instance.gameController.placedIngredient = true;
            Locator.Instance.gameController.hasIngredient = false;
        }
    }

    //add putdown method override
}
