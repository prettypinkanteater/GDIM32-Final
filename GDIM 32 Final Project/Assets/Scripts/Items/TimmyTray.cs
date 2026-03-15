using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyTray : Item
{

    public delegate void QuestsDone();
    public event QuestsDone TrayGiven;
    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.player.ItemUsed += PickUp;
        Locator.Instance.player.putDownEvent += PutDown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PickUp()
    {
        base.PickUp();
        Locator.Instance.gameController.hasIngredient = true;
        Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Utensil", "Appliance");
        Locator.Instance.player.secondCamera.cullingMask = LayerMask.GetMask("Ingredient");
        Locator.Instance.player.secondCamera.enabled = true;
    }

    protected override void PutDown()
    {
        if (Locator.Instance.gameController.burgerDone && Locator.Instance.gameController.WhallyTime)
        {
            base.PutDown();
            this.transform.localPosition = Locator.Instance.player.lookingAt.transform.GetChild(0).position;
            this.transform.localPosition += new Vector3(0, 0.01f, 0);
            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
            Locator.Instance.player.secondCamera.enabled = false;
            Locator.Instance.customer.Animate();
            Locator.Instance.player.enabled = false;
        }
    }
}
