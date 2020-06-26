 using UnityEngine;
using System.Collections;

public class LookX : MonoBehaviour {

	[SerializeField] float sensitivity = 5.0f;

	float mouseX=0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mouseX = Input.GetAxis ("JoystickX");

		Vector3 rot = transform.localEulerAngles;
		rot.y += mouseX *sensitivity;
		transform.localEulerAngles = rot;


	}
}
