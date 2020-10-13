using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselControl : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp() 
    { 
        
    }
    public void MoveDown() 
    { 
        
    }
    public void MoveLeft() 
    { 
        
    }
    public void MoveRight() 
    { 
        
    }
    public void Move() 
    {
        rb.velocity = transform.forward * speed;
    }
}
