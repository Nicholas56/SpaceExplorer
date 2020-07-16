﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float speed=5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"))* Time.deltaTime * 40);

        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.velocity = -transform.up*speed;
    }
}
