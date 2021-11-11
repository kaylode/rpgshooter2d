using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private float maxHealth;
	private float health;

	public void Initialize(float setMaxHealth) {
		maxHealth = setMaxHealth;
		health = maxHealth;
	}

	public void setHealth(float amount) {
		health = amount;
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(health / maxHealth, 1f, 1f);
	}
}
