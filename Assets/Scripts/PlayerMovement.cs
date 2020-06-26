using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	CharacterController varController;

	[SerializeField] float jumpSpeed = 20.0f;
	[SerializeField] float gravity = 1.0f;
	float yVelocity = 0.0f;

	[SerializeField] float moveSpeed = 5.0f;
	public float h;
    public float v;

	// Use this for initialization
	void Start () {
		varController = GetComponent<CharacterController>();
		//anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		//anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		//anim.SetFloat("Direction", h); 	
		Vector3 direction = new	 Vector3(h, 0, v);
		Vector3 velocity = direction * moveSpeed;
		if (varController.isGrounded) {
			if(Input.GetButtonDown("Jump"))
			{
				yVelocity = jumpSpeed;
				//anim.Play("jump");
			}

		} else {
			yVelocity -= gravity;
		}
		velocity.y = yVelocity;

		velocity = transform.TransformDirection (velocity);

		varController.Move(velocity*Time.deltaTime);	

	}
}
