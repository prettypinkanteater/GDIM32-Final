using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject prompt;
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

    public void hidePrompt()
    {
        prompt.SetActive(false);
    }
}
