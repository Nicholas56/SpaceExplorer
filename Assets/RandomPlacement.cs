using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
    int placed = 0;
    public GameObject[] objectsToPlace;

    public GameObject sphere;

    void Start()
    {
        objectsToPlace = new GameObject[transform.childCount];
        for (int i=0;i<transform.childCount;i++)
        {
            objectsToPlace[i] = transform.GetChild(i).gameObject;
        }
        RandomGeneration();
    }

    public void RandomGeneration()
    {
        Vector3 NewLocation;
        bool isInside;

        GameObject objectToPlace;

        for (int i = 0; i < objectsToPlace.Length; i++)
        {
            objectToPlace = objectsToPlace[i];
            NewLocation = (Random.insideUnitSphere)*500;
            isInside = Physics.CheckSphere(NewLocation, objectToPlace.transform.GetComponent<SphereCollider>().radius);
            
            while(isInside)
            {
                NewLocation = (Random.insideUnitSphere * 500);
                isInside = Physics.CheckSphere(NewLocation, objectToPlace.transform.GetComponent<SphereCollider>().radius);
            }
            objectToPlace.transform.position = NewLocation;

        }
        sphere.SetActive(true);


    }


}
