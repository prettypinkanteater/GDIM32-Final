using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Utensil : Item
{
    bool chopable;
    bool chopping;
    
    void Start()
    {
        Locator.Instance.player.ItemUsed += PickUp;
    }

    void Update()
    {
        if(chopable == true && Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Animator>().ResetTrigger("Stop");
            GetComponent<Animator>().SetTrigger("Use");
            chopping = true;
        }
        else
        {
            GetComponent<Animator>().ResetTrigger("Use");
            GetComponent<Animator>().SetTrigger("Stop");
            chopping = false;
        }
    }

    protected override void PickUp()
    {
        base.PickUp();
        transform.rotation = Locator.Instance.player.transform.rotation;
        chopable = true;
    }
}
