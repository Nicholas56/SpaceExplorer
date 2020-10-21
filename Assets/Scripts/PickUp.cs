using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameEvent gameEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameEvent.Raise();
            Destroy(gameObject, 1);
        }
    }
}
