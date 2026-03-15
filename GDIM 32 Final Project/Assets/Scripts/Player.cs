using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] private float castRadius = 2;
    [SerializeField] private float castDistance = 2;
    [SerializeField] public Camera mainCamera;
    [SerializeField] public Camera secondCamera;

    public GameObject lookingAt;
    [SerializeField]  private bool promptOn;
    [SerializeField]  private bool prompt2on;
    [SerializeField]  public bool dialoguePromptOn;

    CharacterController controller;
    Vector3 velocity;
    Vector2 look;

    public delegate void UseItem();
    public event UseItem ItemUsed;

    public delegate void UseIngredient();
    public event UseIngredient IngredientUsed;

    public delegate void drop();
    public event drop putDownEvent;

    public delegate void chop();
    public event chop Chop;

    public delegate void chopAnim();
    public event chopAnim ChopAnim;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
      
        //Makes it so the player can only move and look while not in dialogue
        if (!Locator.Instance.gameController.inDialogue)
        {
            updateMovement();
            updateLook();
        }


        RaycastHit[] rayHit = Physics.SphereCastAll(transform.localPosition + (transform.forward * 2) + Vector3.down, castRadius, transform.forward, castDistance, LayerMask.GetMask("Ingredient", "Manager", "Utensil", "Appliance")); ;
        // Old: if (Physics.SphereCast(transform.localPosition, castRadius, transform.forward, out hit, castDistance, LayerMask.GetMask("Item", "Manager")))
        if (rayHit.Length == 0)
        {
            Locator.Instance.ui.hidePrompt();
            promptOn = false;
            Locator.Instance.ui.hidePrompt2();
            prompt2on = false;
            Locator.Instance.ui.hideDialoguePrompt();
            dialoguePromptOn = false;
        }
            foreach (RaycastHit collider in rayHit)
            {
                Locator.Instance.ui.hidePrompt();
                promptOn = false;
                Locator.Instance.ui.hidePrompt2();
                prompt2on = false;
                Locator.Instance.ui.hideDialoguePrompt();
                dialoguePromptOn = false;

            if (collider.collider != null)
                {
                    string colliderTag = collider.collider.gameObject.tag;
                    lookingAt = collider.collider.gameObject;
                //Debug.Log(lookingAt.name);

                    switch (colliderTag)
                    {

                        case ("appliance"):
                            if ((Locator.Instance.gameController.hasIngredient))
                            {
                                Locator.Instance.ui.showPrompt();
                                promptOn = true;

                            }
                            else if (((Locator.Instance.gameController.hasItem && Locator.Instance.gameController.placedIngredient)) || 
                                    (Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.hasItem && Locator.Instance.gameController.fryCOOKED))
                            {
                                //Debug.Log("prompt2");
                                Locator.Instance.ui.showPrompt2();
                                prompt2on = true;

                            }
                            Locator.Instance.ui.hideDialoguePrompt();
                            break;
                        case ("utensil"):
                            if ((Locator.Instance.gameController.placedIngredient) || (Locator.Instance.gameController.fryCOOKED && Locator.Instance.gameController.burgerInProgress))
                            {
                                Locator.Instance.ui.showPrompt();
                                promptOn = true;

                            }
                            Locator.Instance.ui.hideDialoguePrompt();
                            break;

                        case ("ingredient"):
                            if (Locator.Instance.gameController.hasIngredient == false && Locator.Instance.gameController.placedIngredient == false && Locator.Instance.gameController.hasItem == false)
                            {
                                if (Locator.Instance.gameController.fryInProgress  || Locator.Instance.gameController.burgerInProgress )
                                {
                                Locator.Instance.ui.showPrompt();
                                promptOn = true;
                                }
                            }
                            Locator.Instance.ui.hideDialoguePrompt();
                            break;
                        case ("manager"):
                            RaycastHit hit;
                            if (Physics.Raycast(transform.localPosition, transform.forward, out hit, 15, LayerMask.GetMask("Manager")) && !Locator.Instance.gameController.inDialogue)
                            {
                                Locator.Instance.ui.showDialoguePrompt();
                                Locator.Instance.ui.hidePrompt();
                                Locator.Instance.ui.hidePrompt2();
                                dialoguePromptOn = true;
                                promptOn = false;
                                prompt2on = false;
                            }
                            else
                            {
                                Locator.Instance.ui.hideDialoguePrompt();
                            }


                            /* Saving for stab implementation - probably only on click?
                            if (Locator.Instance.gameController.hasItem == true)
                            {
                                Locator.Instance.ui.showPrompt();
                                promptOn = true;
                            }
                            */

                            //promptOn = true;

                            break;
                    }
                }
            }

        if (Input.GetKeyDown(KeyCode.E) && promptOn)
        {
            if (Locator.Instance.gameController.hasIngredient)
            {
                Debug.Log("Put Down event");
                putDownEvent.Invoke();
            }
            else
            {
                Debug.Log("Pick up event");
                if (Locator.Instance.gameController.burgerInProgress && Locator.Instance.gameController.fryCOOKED)
                {
                    Debug.Log("Spatula Picked Up");
                    ItemUsed.Invoke();
                    Locator.Instance.gameController.burgerFlipped = false;

                }
                else
                {
                    Debug.Log("Any other item picked up");
                    IngredientUsed.Invoke();
                }
            }

        }
        if (Input.GetMouseButtonDown(0) && prompt2on)
        {
            Debug.Log("chop");
            ChopAnim.Invoke();
            //Chop.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition + (transform.forward * 2 * castDistance) + Vector3.down, castRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.localPosition, transform.forward * 15);
    }

    void updateMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        controller.Move((input * movementSpeed + velocity) * Time.deltaTime);
    }

    void updateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    public void ChopInvoke()
    {
        Chop.Invoke();
    }

}
