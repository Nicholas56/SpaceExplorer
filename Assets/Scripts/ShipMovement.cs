using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float speed=5;

    public PlayerControls controls;


    // Start is called before the first frame update
    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void OnLook(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
        //inputDirection = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    Vector2 inputMovement;
    bool currentInput = false;
    private bool useOldInputManager;

    void FixedUpdate()
    {
       
            CalculateDirection();
        

    }

    private void Update()
    {
        if (useOldInputManager)
        {
            var v = Input.GetAxisRaw("Vertical");
            var h = Input.GetAxisRaw("Horizontal");
            inputMovement = new Vector2(h, v);
        }
        if (inputMovement == Vector2.zero)
        {
            currentInput = false;
        }
        else if (inputMovement != Vector2.zero)
        {
            currentInput = true;
        }
    }

    void CalculateDirection()
    {
        Quaternion deltaRotation =
    Quaternion.Euler(new Vector3(-inputMovement.y, 0, inputMovement.x) * (Time.deltaTime / 2));
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.velocity = -transform.up * speed;
    }

  
        /**
    private void FixedUpdate()
    {
        //Quaternion deltaRotation = 
        //Quaternion.Euler(new Vector3(CrossPlatformInputManager.GetAxis("Vertical"), 0, CrossPlatformInputManager.GetAxis("Horizontal"))* Time.deltaTime * 40);

        //rb.MoveRotation(rb.rotation * deltaRotation);
        //rb.velocity = -transform.up*speed;
    }*/
}
