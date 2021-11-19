using UnityEngine;
using System.Collections;

public class Enemy : Character 
{

	public float attackRate = 0.3f;
	protected float lastAttack = 0f;

	public void MoveTo(Vector3 position)
	{
		Vector3 direction = (position - transform.position).normalized;
		Vector2 headingDirection = new Vector2(direction.x * speed, direction.y * speed);
		this.rb.velocity = headingDirection;
	}

	protected override void Die()
	{
		Destroy(gameObject);
	}

	public override void GetDamaged(float value)
	{
		this.healthBar.UpdateHealth(-value);
	}
}
