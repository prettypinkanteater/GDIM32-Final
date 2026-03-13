using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] Animator leftAnimatorController;
    [SerializeField] Animator rightAnimatorController;
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
    }
    void CloseDoors()
    {
        leftAnimatorController.SetBool("FridgeOpen", false);
        rightAnimatorController.SetBool("FridgeOpen", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
