using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool inDialogue = false;
    
    public bool hasIngredient = false;
    public bool placedIngredient = false;
    public bool hasItem = false;

    public bool rawPotato = true;
    public bool cutPotato = false;
    public bool fryInProgress = false;
    public bool fryCOOKED = false;
    public bool fryDone = false;

    public bool burgerInProgress = false;
    public bool burgerFlipped = false;
    public bool burgerOnTray = false;
    public bool burgerDone = false;

    public bool WhallyTime = false;

    public GameObject fakeTray;
    

    //private delegate void TimerFinished();
    //private event TimerFinished FoodDone;

    public delegate void QuestOneDone();
    public event QuestOneDone FryDone;

    public delegate void QuestTwoDone();
    public event QuestTwoDone BurgerDone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (burgerDone)
        {
            fakeTray.SetActive(true);
            fakeTray.GetComponent<TimmyTray>().enabled = true;
            if(GameObject.Find("FryStates") != null)
            {
                GameObject.Find("FryStates").SetActive(false);
            }
            if(GameObject.Find("Food_French Fries") != null)
            {
                GameObject.Find("Food_French Fries").SetActive(false);
            }
            //GameObject.Find("Timmy Tray").SetActive(false);
        }
    }

    public void FryQuestDone()
    {
        fryDone = true;
        fryInProgress = false;
        fryCOOKED = false;
        cutPotato = false;
        placedIngredient = false;

        Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
        Locator.Instance.player.secondCamera.enabled = false;

        GameObject.Find("FryStates").layer = 6;

        GameObject.Find("Timmy Tray").tag = "Untagged";

        //GameObject.Find("Patty").layer = 6;
        //GameObject.Find("Patty").GetComponent<Ingredient>().enabled = true;
        FryDone.Invoke();
        
        // Call UI update event 
    }

    public void burgerQuestDone()
    {
        //burgerDone = true;
        fryCOOKED = false;
        Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
        Locator.Instance.player.secondCamera.enabled = false;
        GameObject.Find("Timmy Tray").tag = "Untagged";
        GameObject.Find("BottomBun").SetActive(false);
        GameObject.Find("TopBun").SetActive(false);
        GameObject.Find("Cheese").SetActive(false);
        GameObject.Find("Spatula").SetActive(false);

        BurgerDone.Invoke();
        GameObject.Find("Timmy Tray").SetActive(false);
        //GameObject.Find("FakeTray").SetActive(true);
    }

    public void ResetPickup()
    {
        Debug.Log("Reset Pickup");
        placedIngredient = false;
        hasIngredient = false;
        hasItem = false;
        
    }
}
