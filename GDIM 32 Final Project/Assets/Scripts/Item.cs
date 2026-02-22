using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void PickUp()
    {
        transform.parent = Locator.Instance.player.transform;
        transform.localPosition = new Vector3(2, 2, 1);
    }

    protected void PutDown()
    {
        transform.parent = null;
    }
}
