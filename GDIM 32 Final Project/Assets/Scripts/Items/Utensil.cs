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

    void Start()
    {
        Locator.Instance.player.ItemUsed += CutManager;
        Locator.Instance.player.ItemUsed += PickUp;
        Locator.Instance.player.Chop += PutDown;
        
    }

    void Update()
    {
        if(chopable == true && (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)))
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
        if(Locator.Instance.gameController.placedIngredient == true && chopable != true)
        {
            Locator.Instance.ui.hidePrompt();
            base.PickUp();
            GetComponent<Animator>().SetTrigger("Position");
            chopable = true;
            Locator.Instance.gameController.hasItem = true;

            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Appliance");
            Locator.Instance.player.secondCamera.cullingMask = LayerMask.GetMask("Utensil");
            Locator.Instance.player.secondCamera.enabled = true;
        }
        
    }

    protected override void PutDown()
    {
        Locator.Instance.ui.hidePrompt();
        Locator.Instance.gameController.hasItem = false;

        Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
        Locator.Instance.player.secondCamera.enabled = false;
        Destroy(this.gameObject);
        

    }

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
