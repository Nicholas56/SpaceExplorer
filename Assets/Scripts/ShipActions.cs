using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipActions : MonoBehaviour
{
    Rigidbody rb;
    bool engineOn;
    [SerializeField] float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = engineOn == true ? transform.forward * speed : transform.forward*0 ;

        if (Input.GetKeyDown(KeyCode.Space)) { IgniteEngine(); }
        if (Input.GetAxis("Horizontal") != 0) { TurnShip(Input.GetAxis("Horizontal")); }
    }

    public void IgniteEngine()
    {
        engineOn = !engineOn;
        Debug.Log(123);
    }

    public void TurnShip(float input)
    {
        Vector3 turn = input * transform.right;
    }
}
