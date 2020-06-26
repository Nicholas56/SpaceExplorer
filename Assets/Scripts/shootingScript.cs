using UnityEngine;
using System.Collections;

public class shootingScript : MonoBehaviour {

	[SerializeField] int damageDealt=20;

	// Use this for initialization
	void Start () {
		Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
		}

		if (Input.GetButtonDown ("Fire1")) {
			//Make a raycast with the line starting from center of camera
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
			//Send the raycast and if the raycast hit something, print out the name to console
			if (Physics.Raycast (mouseRay, out hitInfo)) {
                print(hitInfo.transform.name);
                Debug.DrawLine(transform.position, hitInfo.point,Color.red,5.0f);
				Health enemyHealth = hitInfo.transform.GetComponent<Health>();
				if(enemyHealth !=null)
				{
					enemyHealth.Damage(damageDealt);
				}
			}
		}
	}
}
