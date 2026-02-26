using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{

    private bool hasIngredient;
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
        base.PickUp();
        transform.rotation = Locator.Instance.player.transform.rotation;
        hasIngredient = true;

    }

    protected override void PutDown()
    {

    }

    //add putdown method override
}
