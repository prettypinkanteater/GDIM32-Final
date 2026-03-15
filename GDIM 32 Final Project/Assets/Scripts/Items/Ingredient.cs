using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    //[SerializeField] private GameObject newModel;
    [SerializeField] private GameObject potato;
    [SerializeField] private GameObject cut;
    [SerializeField] private GameObject cooked;

    [SerializeField] private GameObject rawPatty;
    [SerializeField] private GameObject cookedPatty;
    [SerializeField] private GameObject burger;


    public GameObject fakeFries;

    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance.player.putDownEvent += PutDown;
        Locator.Instance.player.IngredientUsed += PickUp;
        Locator.Instance.player.Chop += changeModel;
        Locator.Instance.player.Chop += chopIngredient;
        Locator.Instance.gameController.BurgerDone += becomeBurger;
    }

    // Update is called once per frame
    void Update()
    {
        if (Locator.Instance.gameController.fryCOOKED)
        {
            changeModel();
            if (Locator.Instance.gameController.hasIngredient)
                 {
                        this.gameObject.layer = 0;
                 }
            //Locator.Instance.gameController.FryQuestDone();
            //Locator.Instance.gameController.burgerInProgress = true;
        }
       if(Locator.Instance.gameController.cutPotato)
        {
            potato.SetActive(false);
            cut.SetActive(true);
            cooked.SetActive(false);
        }
        if (Locator.Instance.gameController.fryCOOKED && !Locator.Instance.gameController.burgerOnTray)
        {
            potato.SetActive(false);
            cut.SetActive(false);
            cooked.SetActive(true);
        }

    }

    protected override void PickUp()
    {
        if((Locator.Instance.gameController.hasItem == false && Locator.Instance.gameController.placedIngredient == false) || Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.fryCOOKED && Locator.Instance.gameController.hasItem && !Locator.Instance.gameController.burgerFlipped)
        {
            base.PickUp();
            Locator.Instance.gameController.hasIngredient = true;

            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Utensil", "Appliance");
            Locator.Instance.player.secondCamera.cullingMask = LayerMask.GetMask("Ingredient");
            Locator.Instance.player.secondCamera.enabled = true;

            if(Locator.Instance.gameController.fryCOOKED)
            {
                //this.gameObject.tag = "Untagged";
                //this.gameObject.layer = 0;
            }
        }
    }

    protected override void PutDown()
    {
        if(Locator.Instance.gameController.hasIngredient == true && Locator.Instance.player.lookingAt.tag == "appliance") 
        {
            if (Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasItem && Locator.Instance.gameController.hasIngredient && !Locator.Instance.gameController.WhallyTime)
            {
                Locator.Instance.gameController.burgerOnTray = true;
                Locator.Instance.gameController.burgerQuestDone();
                Locator.Instance.gameController.WhallyTime = true;
            }
            Locator.Instance.gameController.hasIngredient = false;
            //GetComponent<Collider>().enabled = false;
            base.PutDown();
            Locator.Instance.gameController.placedIngredient = true;
            
            if(Locator.Instance.gameController.cutPotato)
            {
                if (Locator.Instance.gameController.fryCOOKED)
                {
                    
                    transform.position = new Vector3(270.45f, 4.195f, -10.77f);
                    //this.gameObject.tag = "Untagged";
                    //transform.GetChild(0).gameObject.tag = "Untagged";
                    //transform.GetChild(2).gameObject.layer = 0;

                    fakeFries.SetActive(true);
                    cooked.SetActive(false);

                    potato = rawPatty;
                    cut = burger;
                    cooked = cookedPatty;

                    transform.position = new Vector3(245.123f, 3.836f, -11.07f);
                    potato.transform.position = new Vector3(245.123f, 3.836f, -11.07f);
                    cut.transform.position = new Vector3(245.123f, 3.836f, -11.07f);
                    cooked.transform.position = new Vector3(245.123f, 3.836f, -11.07f);
                    potato.SetActive(true);

                    Locator.Instance.gameController.ResetPickup();
                    Locator.Instance.gameController.FryQuestDone();
                    //gameObject.GetComponent<Ingredient>().enabled = false;

                }
                else
                {
                    transform.position = new Vector3(262.77f, 3.082f, -10.92f);
                }
            } 
            else
            {
                base.PutDown();

                this.transform.localPosition = Locator.Instance.player.lookingAt.transform.GetChild(0).position;
                this.transform.localPosition += new Vector3(0, 0.01f, 0);
            }
            
            
            
            Locator.Instance.player.mainCamera.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Manager", "Ingredient", "Utensil", "Appliance");
            Locator.Instance.player.secondCamera.enabled = false;
        }
        /*if (Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasIngredient)
        {
            GameObject.Find("Food_French Fries").transform.SetParent(GameObject.Find("Griller").transform);

        }*/
    }

    protected void chopIngredient()
    {
        if(Locator.Instance.gameController.burgerInProgress)
        {
            transform.parent = GameObject.Find("Utensils").transform.GetChild(2).transform;
            transform.position = GameObject.Find("Utensils").transform.GetChild(2).transform.position;
            Locator.Instance.gameController.hasIngredient = true;
        }
    }

    protected void changeModel()
    {
        Debug.Log("AAAAAAAAAAAAA");
        //Locator.Instance.ui.hidePrompt2();
        if (Locator.Instance.gameController.fryInProgress)
        {
            Locator.Instance.gameController.cutPotato = true;
            Locator.Instance.gameController.rawPotato = false;
            Locator.Instance.gameController.placedIngredient = false;
        }

        //Destroy(this.gameObject);
        this.gameObject.GetComponent<Collider>().enabled = true;
        

    }

    public void becomeBurger()
    {
        cut.SetActive(true);
        cooked.SetActive(true);
        Locator.Instance.gameController.burgerDone = true;
    }
}
