using UnityEngine;
using System.Collections;

public class healPickup : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        print("pick up");
        if(collider.CompareTag("Player"))
        {
           
            Health health = GetComponent<Health>();
                if(health!=null)
                {
                    health.Damage(-50);
                }
        }
    }
}
