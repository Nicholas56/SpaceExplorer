using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	float nextTimeAttackIsAllowed = -1.0f;

	[SerializeField] float attackDelay = 1.0f;

	[SerializeField] int damageDealt =5;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player"&&Time.time>=nextTimeAttackIsAllowed) {
			Health playerHealth = other.GetComponent<Health>();
			playerHealth.Damage(damageDealt);
            nextTimeAttackIsAllowed = Time.time + attackDelay;                                       
		}
	}
}

