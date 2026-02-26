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
        if(Locator.Instance.gameController.placedIngredient == true)
        {
            Locator.Instance.ui.hidePrompt();
            base.PickUp();
            GetComponent<Animator>().SetTrigger("Position");
            chopable = true;
            Locator.Instance.gameController.hasItem = true;
        }
        
    }

    protected override void PutDown()
    {
        Locator.Instance.ui.hidePrompt();

    }
    //override base putdown method so that game object dies
}
