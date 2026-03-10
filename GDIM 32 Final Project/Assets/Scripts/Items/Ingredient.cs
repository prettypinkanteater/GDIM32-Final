using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    //[SerializeField] private GameObject newModel;
    [SerializeField] private GameObject potato;
    [SerializeField] private GameObject cut;
    [SerializeField] private GameObject cooked;

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
        if (Locator.Instance.gameController.fryCOOKED)
        {
            changeModel();
        }
       if(Locator.Instance.gameController.cutPotato)
        {
            potato.SetActive(false);
            cut.SetActive(true);
            cooked.SetActive(false);
        }
        if (Locator.Instance.gameController.fryCOOKED)
        {
            potato.SetActive(false);
            cut.SetActive(false);
            cooked.SetActive(true);
        }
    }

    protected override void PickUp()
    {
        if(Locator.Instance.gameController.hasItem == false && Locator.Instance.gameController.placedIngredient == false)
        {
            base.PickUp();
            Locator.Instance.gameController.hasIngredient = true;

            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Utensil", "Appliance");
            Locator.Instance.player.secondCamera.cullingMask = LayerMask.GetMask("Ingredient");
            Locator.Instance.player.secondCamera.enabled = true;
        }
    }

    protected override void PutDown()
    {
        if(Locator.Instance.gameController.hasIngredient == true && Locator.Instance.player.lookingAt.tag == "appliance") 
        {
            Locator.Instance.gameController.hasIngredient = false;
            //GetComponent<Collider>().enabled = false;
            base.PutDown();

            if(Locator.Instance.gameController.cutPotato)
            {
                if (Locator.Instance.gameController.fryCOOKED)
                {
                    transform.position = new Vector3(270.45f, 4.195f, -10.77f);
                    this.gameObject.tag = "Untagged";
                    transform.GetChild(0).gameObject.tag = "Untagged";
                    Locator.Instance.gameController.ResetPickup();

                }
                else
                {
                    transform.position = new Vector3(262.77f, 3.082f, -10.92f);
                }
            } 
            else
            {
                transform.localPosition = Locator.Instance.player.lookingAt.transform.GetChild(0).position;
                transform.localPosition += new Vector3(0, 0.01f, 0);
            }
                
            Locator.Instance.gameController.placedIngredient = true;

            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
            Locator.Instance.player.secondCamera.enabled = false;
        }
    }

    protected void changeModel()
    {
        Locator.Instance.ui.hidePrompt2();
        if (Locator.Instance.gameController.fryInProgress)
        {
            Locator.Instance.gameController.cutPotato = true;
            Locator.Instance.gameController.rawPotato = false;
            Locator.Instance.gameController.placedIngredient = false;
        }

        //Destroy(this.gameObject);
        this.gameObject.GetComponent<Collider>().enabled = true;
        

    }
}
