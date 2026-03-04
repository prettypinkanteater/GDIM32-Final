using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool promptOn;

    CharacterController controller;
    Vector3 velocity;
    Vector2 look;

    public delegate void UseItem();
    public event UseItem ItemUsed;

    public delegate void drop();
    public event drop putDownEvent;


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
        updateMovement();
        updateLook();

        RaycastHit hit;
        
        if (Physics.SphereCast(transform.localPosition, castRadius, transform.forward, out hit, castDistance, LayerMask.GetMask("Item")))
        {
            string colliderTag = hit.collider.gameObject.tag;
            lookingAt = hit.collider.gameObject;
            
            switch (colliderTag) 
            {
                
                case ("utensil"):
                    if (Locator.Instance.gameController.placedIngredient)
                    {
                        Locator.Instance.ui.showPrompt();
                        promptOn = true;
                    }
                    break;
                case ("appliance"):
                    if (Locator.Instance.gameController.hasIngredient)
                    {
                        Locator.Instance.ui.showPrompt();
                        promptOn = true;
                    }
                    break;
                case ("ingredient"):
                    if(Locator.Instance.gameController.hasIngredient == false && Locator.Instance.gameController.placedIngredient == false && Locator.Instance.gameController.hasItem == false)
                    {
                        Locator.Instance.ui.showPrompt();
                        promptOn = true;
                    }
                    break;
                case ("manager"):
                    if (Locator.Instance.gameController.hasItem == true)
                    {
                        Locator.Instance.ui.showPrompt();
                        promptOn = true;
                    }
                    break;
            }

        } else
        {
            Locator.Instance.ui.hidePrompt();
            promptOn = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && promptOn)
        {
            if(Locator.Instance.gameController.hasIngredient)
            {
                putDownEvent.Invoke();
            } else
            {
                ItemUsed.Invoke();
            }
                
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition + transform.forward * castDistance, castRadius);
        //Physics.SphereCast(transform.position, castRadius, transform.forward, out hit, castDistance))
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
}
