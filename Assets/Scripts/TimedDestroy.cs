using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    float timer;
    public float targetTime = 5;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > targetTime)
        {
            Destroy(gameObject);
        }
    }
}
