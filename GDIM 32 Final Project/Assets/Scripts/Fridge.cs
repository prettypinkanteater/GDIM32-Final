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
        Locator.Instance.gameController.FryDone += OpenDoors;
    }

    void OpenDoors()
    {
        leftAnimatorController.SetBool("FridgeOpen", true);
        rightAnimatorController.SetBool("FridgeOpen", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
