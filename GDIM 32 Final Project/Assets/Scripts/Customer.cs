using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    public void Animate()
    {
        _animator.SetBool("PlacedTray", true);
    }
}
