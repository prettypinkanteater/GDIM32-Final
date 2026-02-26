using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Locator.Instance.gameController.placedIngredient)
        {
            GetComponent<Collider>().enabled = false;
        }

        if (Locator.Instance.gameController.hasItem)
        {
            GetComponent<Collider>().enabled = true;
        }
    }

    protected override void PickUp()
    {
        
    }
}
