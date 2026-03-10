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
    public bool fryInProgress = true;
    public bool fryCOOKED = false;
    public bool fryDone = false;

    public bool burgerInProgress = false;
    public bool burgerDone = false;

    

    private delegate void TimerFinished();
    private event TimerFinished FoodDone;

    // Start is called before the first frame update
    void Start()
    {
        fryInProgress = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FryQuestDone()
    {
        fryDone = true;
    }

    public void ResetPickup()
    {
        placedIngredient = false;
        hasIngredient = false;
        hasItem = false;
        
    }
}
