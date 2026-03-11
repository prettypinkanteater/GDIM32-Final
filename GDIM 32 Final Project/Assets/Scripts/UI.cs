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

    void Start()
    {
        Locator.Instance.gameController.FryDone += FriesGoalsDone;
        Locator.Instance.dialogueController.StartFryQuest += StartGoalDone;
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

    void FriesGoalsDone()
    {
        goals.text = "Goals: \n - Talk to the manager";
    }
    void StartGoalDone()
    {
        goals.text = "Goals: \n - Make the fries \n - Give Timmy the fries \n - (Optional) Talk to the manager for help";
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
