using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utensil : Item
{
    bool chopable;
    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.player.ItemUsed += PickUp;
    }

    // Update is called once per frame
    void Update()
    {
        if(chopable == true && Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetTrigger("Chop");
        }
        else
        {
            GetComponent<Animator>().ResetTrigger("Chop");
        }
    }

    protected override void PickUp()
    {
        base.PickUp();
        transform.localRotation = Locator.Instance.player.transform.rotation;
        chopable = true;
    }
}
