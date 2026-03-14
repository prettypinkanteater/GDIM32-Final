using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Utensil : Item
{
    bool chopable;
    bool chopping;
    bool cutManager;
    Vector3 rotation;

    [SerializeField] GameObject knife;
    [SerializeField] GameObject spat;

    void Start()
    {
        //Locator.Instance.player.ItemUsed += CutManager;
        Locator.Instance.player.IngredientUsed += PickUp;
        Locator.Instance.player.ItemUsed += PickUp;
        Locator.Instance.player.Chop += PutDown;
        
    }

    void Update()
    {
        if(Locator.Instance.gameController.fryCOOKED && Locator.Instance.gameController.burgerInProgress)
        {
            this.gameObject.GetComponent<Collider>().enabled = true;
        }
        if(Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasItem)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
        if (Locator.Instance.gameController.burgerInProgress)
        {
            spat.SetActive(true);
        }

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
        if((Locator.Instance.gameController.placedIngredient == true) || (Locator.Instance.gameController.fryCOOKED && Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.burgerFlipped))
        {
            Locator.Instance.ui.hidePrompt();
            base.PickUp();
            if(Locator.Instance.gameController.burgerInProgress == true)
            {
                GetComponent<Animator>().SetTrigger("SpatPosition");
                this.gameObject.layer = 0;
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Position");
            }

            chopable = true;
            Locator.Instance.gameController.hasItem = true;

            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Appliance");
            Locator.Instance.player.secondCamera.cullingMask = LayerMask.GetMask("Utensil");
            Locator.Instance.player.secondCamera.enabled = true;
        }
        // if(Locator.Instance.gameController.burgerInProgress )
        
    }

    protected override void PutDown()
    {
        Debug.Log("Utensil put down");
        Locator.Instance.ui.hidePrompt();
        

        Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
        Locator.Instance.player.secondCamera.enabled = false;
        
        if(Locator.Instance.gameController.fryInProgress)
        {
            Locator.Instance.gameController.hasItem = false;
            transform.parent = null;
            knife.SetActive(false);
            transform.position = new Vector3(258.764f, 3.803f, -11.24f);
            transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
            //spat.SetActive(true);
        }
        
        

    }

    //Audrey rememmber to pu animation starting trugger in use method

    protected void CutManager()
    {
        /*
        if (chopable == true)
        {  
            cutManager = true;

            //For updating UI - should probably be done via event
            Locator.Instance.ui.goals.text = "<#880808>Goals: \n<s>- Prepare potato for cutting </s> \n<s>- Don't get fired</s>";
        }
        */
    }
    //This is called from an animation event at the end of Chop
    protected void EndScene()
    {
        /*
        if (cutManager) {
            SceneManager.LoadScene("Main");
        }
        */
    }

    //override base putdown method so that game object dies
}
