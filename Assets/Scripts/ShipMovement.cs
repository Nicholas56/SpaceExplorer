using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float speed=5;
    PlayerControls controls;

    [SerializeField] GameObject probe;
    [SerializeField] GameObject missile;
    GameObject currentProjectile;

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
        if (Input.GetButton("Jump"))
        {
            Quaternion deltaRotation =
                Quaternion.Euler(new Vector3(-value.Get<Vector2>().y, value.Get<Vector2>().x) * (Time.deltaTime * 10));

            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    } 

    public void OnFire(InputValue value)
    {
        if (Input.GetButton("Jump"))
        {
            GameObject newProbe = Instantiate(currentProjectile, transform.position - Vector3.down, transform.rotation);
            newProbe.GetComponent<Rigidbody>().AddForce(transform.forward * 25, ForceMode.Impulse);
        }
    }

    public void OnChangeWeapon(InputValue value)
    {
        if (currentProjectile == probe) { currentProjectile = missile; } else { currentProjectile = probe; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentProjectile = probe;
    }

    public void SetProbe() { currentProjectile = probe; }
    public void SetMissile() { currentProjectile = missile; }

    Vector2 inputMovement;
    bool currentInput = false;
    private bool useOldInputManager;

    private void FixedUpdate()
    {
        /*
        Quaternion deltaRotation = 
        Quaternion.Euler(new Vector3(CrossPlatformInputManager.GetAxis("Vertical"), CrossPlatformInputManager.GetAxis("Horizontal"))* Time.deltaTime * 40);

        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.velocity = transform.forward*speed;
        */

        if (Input.GetButton("Jump"))
        {
            controls.Enable();
            rb.velocity = transform.forward * speed;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            controls.Disable();
            rb.velocity = Vector3.zero;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}
