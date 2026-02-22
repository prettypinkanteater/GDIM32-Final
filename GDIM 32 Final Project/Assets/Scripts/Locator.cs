using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public Player player { get; private set; }
    public UI ui { get; private set; }
    // change player class name as needed, eg class is actually not named player lol
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject playerGameObject = GameObject.Find("Player");
        player = playerGameObject.GetComponent<Player>();

        GameObject uiGameObject = GameObject.Find("UI");
        ui = uiGameObject.GetComponent<UI>();

    }

    
    void Start()
    {
       // once player object is created, find the gameobject via name and get its player component for the variable above.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
