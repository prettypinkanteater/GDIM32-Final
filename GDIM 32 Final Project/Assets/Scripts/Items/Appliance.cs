using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Appliance : Item
{
    private float _cookingTimer;
    private float _cookingTime = 10.0f;
    

    [SerializeField] Canvas _timerCanvas;
    private TextMeshProUGUI _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _cookingTimer = _cookingTime;
        _timerText = _timerCanvas.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_cookingTimer <= 0f && Locator.Instance.gameController.placedIngredient)
        {
           Locator.Instance.gameController.fryCOOKED = true;
            _timerText.enabled = false;
           Locator.Instance.gameController.ResetBooleans();

        }

        if (this.gameObject.name == "Frier" &&
            Locator.Instance.gameController.placedIngredient &&
            Locator.Instance.gameController.fryInProgress && 
            Locator.Instance.gameController.cutPotato)
        {
            _cookingTimer -= Time.deltaTime;
            int _cookingTimerInt = (int)_cookingTimer;
            _timerText.text = _cookingTimerInt.ToString();
        }
        if (Locator.Instance.gameController.cutPotato && this.gameObject.name == "Cutting Board")         
        {
            GetComponent<Collider>().enabled = false;
        }

    }

    protected override void PickUp()
    {
        
    }

    protected override void PutDown()
    {
        
    }
}
