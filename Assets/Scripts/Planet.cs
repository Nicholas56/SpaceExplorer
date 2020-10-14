using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] int health = 10;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if (collision.gameObject.TryGetComponent(out ShipEffect effect))
            {
                effect.PlayDeath();
            }
        }

        if (collision.gameObject.tag == "Projectile")
        {
            health--;
        }
    }
}
