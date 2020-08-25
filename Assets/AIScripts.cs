using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScripts : MonoBehaviour
{
    [SerializeField] Vector3 target;
    [SerializeField] Vector3 normaltarget;
    bool turning;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position + Vector3.forward;
        StartCoroutine("checkPath");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator checkPath()
    {
        yield return new WaitForSeconds(0.1f);
        Avoidance();
        StartCoroutine("checkPath");

    }

    public void Avoidance()
    {
        //subtract AI thing’s position from waypoint, player, whatever it is going towards…
        //Debug.Log(Mathf.Abs(target.x)+" "+ Mathf.Abs(target.y)+" "+Mathf.Abs(target.z)+(Mathf.Abs(target.x)>450));
        target = transform.position + Vector3.forward;
        
        if (Mathf.Abs(target.x) > 450 || Mathf.Abs(target.y) > 450 || Mathf.Abs(target.z) > 450)
        {
            Debug.Log("Out of boudns");
            Vector3 NewLocation;
            bool isInside;

            NewLocation = (Random.insideUnitSphere) * 500;
            isInside = Physics.CheckSphere(NewLocation, transform.GetComponentInChildren<MeshCollider>().bounds.extents.magnitude);

            while (isInside)
            {
                NewLocation = (Random.insideUnitSphere) * 500;
                isInside = Physics.CheckSphere(NewLocation, transform.GetComponentInChildren<MeshCollider>().bounds.extents.magnitude);
            }

            transform.position = NewLocation;
        }
        else
        {
            Debug.Log(" in bound");
            target = transform.position + Vector3.forward;
            turning = false;

        }
        //normalize it to get direction
        normaltarget = target.normalized;

        //now make a new raycast hit
        //and draw a line from the AI out some distance in the ‘forward direction
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 800f))
        {
            //check that its not hitting itself
            //then add the normalised hit direction to your direction plus some repulsion force
            if (hit.transform != transform)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);

                normaltarget += hit.normal * 400f;
            }

        }

        //now make two more raycasts out to the left and right to make the cornering more accurate and reducing collisions more

        Vector3 leftR = transform.position;
        Vector3 rightR = transform.position;

        leftR.x -= 2;
        rightR.x += 2;

        if (Physics.Raycast(leftR, transform.forward, out hit, 400f))
        {
            if (hit.transform != transform)
            {
                Debug.DrawLine(leftR, hit.point, Color.red);
                normaltarget += hit.normal * 400f;
            }

        }
        if (Physics.Raycast(rightR, transform.forward, out hit, 400f))
        {
            if (hit.transform != transform)
            {
                Debug.DrawLine(rightR, hit.point, Color.red);

                normaltarget += hit.normal * 400f;
            }

        }

        // then set the look rotation toward this new target based on the collisions

        Quaternion torotation = Quaternion.LookRotation(normaltarget);

        //then slerp the rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, torotation, Time.deltaTime * 100f);

        //finally add some propulsion to move the object forward based on this rotation

        transform.position += transform.forward * 20f * Time.deltaTime;
    }
}
