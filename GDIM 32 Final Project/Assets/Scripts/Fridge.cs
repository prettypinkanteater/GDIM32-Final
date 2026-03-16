using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] Animator leftAnimatorController;
    [SerializeField] Animator rightAnimatorController;
    [SerializeField] GameObject fridgeLight;
    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.dialogueController.StartBurgerQuest += OpenDoors;
        Locator.Instance.ui.CloseFridge += CloseDoors;
    }

    void OpenDoors()
    {
        leftAnimatorController.SetBool("FridgeOpen", true);
        rightAnimatorController.SetBool("FridgeOpen", true);
        fridgeLight.SetActive(true);
    }
    void CloseDoors()
    {
        Locator.Instance._audio.Door();
        leftAnimatorController.SetBool("FridgeOpen", false);
        rightAnimatorController.SetBool("FridgeOpen", false);
        fridgeLight.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
