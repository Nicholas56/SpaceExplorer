using UnityEngine;
using System.Collections;

public class Basic : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent;
	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.SetDestination (target.position);
	}
}
