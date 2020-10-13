﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float speed=5;

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
        Quaternion deltaRotation = 
        Quaternion.Euler(new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"))* Time.deltaTime * 40);

        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.velocity = transform.forward*speed;

        if (Input.GetKeyDown(KeyCode.Space)) {rb.angularVelocity = Vector3.zero; }
    }
}
