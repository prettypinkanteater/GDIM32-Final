using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utensil : Item
{
    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.player.ItemUsed += PickUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
