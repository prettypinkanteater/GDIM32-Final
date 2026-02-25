using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Utensil : Item
{
    bool chopable;
    bool chopping;
    Vector3 rotation;
    
    void Start()
    {
        Locator.Instance.player.ItemUsed += PickUp;
        rotation = new Vector3(15.981f, 80.121f, -7.329f);
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
        chopable = true;
    }
}
