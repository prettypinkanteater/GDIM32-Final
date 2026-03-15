using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject prompt;
    [SerializeField] GameObject prompt2;
    [SerializeField] GameObject dialoguePrompt;
    [SerializeField] public TMP_Text goals;

    public delegate void FridgeClose();
    public event FridgeClose CloseFridge;

    void Start()
    {
        Locator.Instance.gameController.FryDone += FriesGoalsDone;
        Locator.Instance.gameController.BurgerDone += FriesGoalsDone;
        Locator.Instance.dialogueController.StartFryQuest += StartGoalDone;
        Locator.Instance.dialogueController.StartBurgerQuest += ShowBurgerGoals;
        Locator.Instance.dialogueController.EndBurgerQuest += ShowEndGoals;
    }

    // Update is called once per frame
    void Update()
    {
        ////For updating UI - should probably be done via event
        //if (Locator.Instance.gameController.fryInProgress)
        //{
            //goals.text = "Goals: \n<s>- Prepare potato for cutting </s> \n- Don't get fired";
        //}
        

    }

    
    void StartGoalDone()
    {
        goals.text = "Objectives: \n - Make the fries \n - Give Timmy the fries \n - (Optional) Talk to the manager for help";
    }
    void FriesGoalsDone()
    {
        goals.text = "Objectives: \n - Talk to the manager";
    }
    void ShowBurgerGoals()
    {
        goals.text = "Objectives: \n - Grill the patty \n - Give Timmy the patty with the spatula \n - (Optional) Talk to the manager for help";
    }
    void ShowEndGoals()
    {
        goals.text = "Objectives: \n - Give the tray to the customer";
    }

    public void showPrompt()
    {
        prompt.SetActive(true);
    }
    public void showPrompt2()
    {
        prompt2.SetActive(true);
    }
    public void showDialoguePrompt()
    {
        dialoguePrompt.SetActive(true);
    }

    public void hidePrompt()
    {
        prompt.SetActive(false);
        if (Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasIngredient)
        {
            CloseFridge.Invoke();
        }
        
    }

    public void hidePrompt2()
    {
        prompt2.SetActive(false);
    }
    public void hideDialoguePrompt()
    {
        dialoguePrompt.SetActive(false);
    }
}
