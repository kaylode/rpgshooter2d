using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar
{
	protected float maxHealth;
	private float health;

	public void Initialize(float maxHealth)
	{
		this.maxHealth = maxHealth;
		this.health = maxHealth;
	}

	public void SetHealth(float value)
	{
		this.health = value;
	}
	public void UpdateHealth(float value)
	{
		this.health += value;
	}

	public float GetHealth()
    {
		return this.health;
    }

}
