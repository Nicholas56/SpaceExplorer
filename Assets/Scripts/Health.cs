using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] int maximumHealth = 100;
	int currentHealth = 0;

	void Start () {
		currentHealth = maximumHealth;
	}

	public bool IsDead { get{ return currentHealth <= 0; } }

	public int getHealth()
	{
		return currentHealth;
	}

    public int getMaxHealth()
    {
        return maximumHealth;
    }

	public void Damage(int damageValue)
	{
		currentHealth -= damageValue;

		if (currentHealth <= 0) {
            Destroy(gameObject);
			}
	}
}
