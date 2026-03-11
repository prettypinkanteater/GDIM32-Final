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
    public bool burgerDone = false;

    

    private delegate void TimerFinished();
    private event TimerFinished FoodDone;

    public delegate void QuestOneDone();
    public event QuestOneDone FryDone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FryQuestDone()
    {
        fryDone = true;
        fryInProgress = false;
        GameObject.Find("Patty").layer = 6;
        GameObject.Find("Patty").GetComponent<Ingredient>().enabled = true;
        FryDone.Invoke();
        // Call UI update event 
    }

    public void ResetPickup()
    {
        placedIngredient = false;
        hasIngredient = false;
        hasItem = false;
        
    }
}
