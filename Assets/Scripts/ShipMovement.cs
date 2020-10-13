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
    GameObject currentProbe;

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
        Quaternion deltaRotation =
            Quaternion.Euler(new Vector3(-value.Get<Vector2>().y, value.Get<Vector2>().x) * (Time.deltaTime * 10));

        rb.MoveRotation(rb.rotation * deltaRotation);

        rb.velocity = transform.forward * speed;
    } 

    public void OnFire(InputValue value)
    {
        DestroyProbe();
        GameObject newProbe = Instantiate(probe, transform.position - Vector3.down, transform.rotation);
        newProbe.GetComponent<Rigidbody>().AddForce(transform.forward * 25, ForceMode.Impulse);

        Invoke("DestroyProbe", 5f);
    }

    void DestroyProbe()
    {
        Destroy(currentProbe);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        if (Input.GetKeyDown(KeyCode.Space)) {rb.angularVelocity = Vector3.zero; }
        
    }
}
