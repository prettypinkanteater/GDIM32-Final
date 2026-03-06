using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    [SerializeField] private GameObject newModel;

    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.player.putDownEvent += PutDown;
        Locator.Instance.player.ItemUsed += PickUp;
        Locator.Instance.player.Chop += changeModel;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    protected override void PickUp()
    {
        if(Locator.Instance.gameController.hasItem == false && Locator.Instance.gameController.placedIngredient == false)
        {
            base.PickUp();
            Locator.Instance.gameController.hasIngredient = true;
        }
    }

    protected override void PutDown()
    {
        if(Locator.Instance.gameController.hasIngredient == true) 
        {
            Locator.Instance.gameController.hasIngredient = false;
            GetComponent<Collider>().enabled = false;
            base.PutDown();
            transform.position = Locator.Instance.player.lookingAt.transform.position;
            transform.localPosition += new Vector3(0, 0.01f, 0);
            Locator.Instance.gameController.placedIngredient = true;

            //For updating UI - should probably be done via event
            Locator.Instance.ui.goals.text = "Goals: \n<s>- Prepare potato for cutting </s> \n- Don't get fired";
        }
    }

    protected void changeModel()
    {
        Instantiate(newModel, this.gameObject.transform.position + new Vector3(0,0.05f, 0), this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
