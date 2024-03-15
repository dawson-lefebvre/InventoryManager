using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FirstPersonPlayerController : MonoBehaviour
{
    //Components
    Rigidbody rb;
    [SerializeField] GameObject cam;
    [SerializeField] float interactDistance = 1;
    InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        inventoryManager = GetComponent<InventoryManager>();
    }

    //Input variables
    [Header("Inputs")]
    [SerializeField] InputAction MoveAction, LookAction, InteractAction, OpenInventoryAction;

    Vector2 MoveValue, LookValue;

    [Header("Movement Variables")]
    [SerializeField] float lookSpeed, moveSpeed;

    private void OnEnable()
    {
        MoveAction.Enable();
        LookAction.Enable();
        InteractAction.Enable();
        OpenInventoryAction.Enable();
    }

    private void OnDisable()
    {
        LookAction.Disable();
        MoveAction.Disable();
        InteractAction.Disable();
        OpenInventoryAction.Disable();
    }

    public bool moving = false;

    // Update is called once per frame
    void Update()
    {
        //Read Input values
        MoveValue = MoveAction.ReadValue<Vector2>();
        LookValue = LookAction.ReadValue<Vector2>();

        if(MoveValue != Vector2.zero)
        {
            if(!moving)
            {
                moving = true;
            }
        }
        else
        {
            if(moving)
            {
                moving = false;
            }
        }

        if(OpenInventoryAction.WasPressedThisFrame())
        {
            inventoryManager.OpenCloseInventory();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void LateUpdate()
    {
        //Rotate player
        transform.Rotate(LookValue.x * Vector3.up * lookSpeed * Time.deltaTime);

        //Move Camera up and down
        cam.transform.Rotate(LookValue.y * Vector3.left * lookSpeed * Time.deltaTime);

        //Clamp Camera
        Vector3 angles = cam.transform.eulerAngles;

        if (angles.x > 45.0f && angles.x < 100f)
        {
            cam.transform.localRotation = Quaternion.Euler(45.0f, 0, 0);
        }

        if (angles.x < 315.0f && angles.x > 180.0f)
        {
            cam.transform.localRotation = Quaternion.Euler(315.0f, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        //Move Player
        transform.Translate(new Vector3(MoveValue.x * moveSpeed * Time.fixedDeltaTime, 0, MoveValue.y * moveSpeed * Time.fixedDeltaTime));  
    }
}
