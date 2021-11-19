using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyAI), typeof(Rigidbody2D))]
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

	// Basic attack, deal damage on touch
	protected override void Attack(Damageable target)
	{
		if (Time.time > this.attackRate + this.lastAttack)
		{
			Vector3 playerPosition = target.transform.position;
			Vector3 direction = (playerPosition - transform.position).normalized;
			Vector2 headingDirection = new Vector2(direction.x * this.speed * 1.25f, direction.y * this.speed * 1.25f);
			this.rb.velocity = headingDirection;

			target.GetDamaged(this.damage);
			this.lastAttack = Time.time;

			// Print damage
			GameManager.instance.ShowText((-this.damage).ToString(), 100, Color.red, transform.position + new Vector3(0.5f,1.75f,0), Vector3.up, 2.0f);
		}
	}

	protected void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			this.Attack(collision.gameObject.GetComponent<Damageable>());
		}
	}
}
