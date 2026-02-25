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

    protected virtual void PickUp()
    {
        transform.parent = Locator.Instance.player.transform;
        transform.localPosition = new Vector3(1, 0, 2);
        GetComponent<BoxCollider>().enabled = false;
    }

    protected void PutDown()
    {
        transform.parent = null;
    }
}
