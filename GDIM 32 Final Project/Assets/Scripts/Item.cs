using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    void Start()
    {
        Locator.Instance.player.ItemUsed += PickUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickUp()
    {
        transform.parent = Locator.Instance.player.transform;
        transform.localPosition = new Vector3(2, 2, 1);
    }

    void PutDown()
    {
        transform.parent = null;
    }
}
