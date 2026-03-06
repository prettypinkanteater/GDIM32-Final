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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
