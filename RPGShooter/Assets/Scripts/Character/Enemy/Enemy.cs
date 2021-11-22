using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyAI), typeof(Rigidbody2D))]
public class Enemy : Character 
{

	public GameObject reward;
	public float dropRate;
	public float attackRate = 0.3f;
	public float pushForce = 30000f;
	protected float lastAttack = 0f;

	public virtual void MoveTo(Vector3 position)
	{
		if (this.moveAble)
		{
			Vector3 direction = (position - transform.position).normalized;
			Vector2 headingDirection = new Vector2(direction.x * speed, direction.y * speed);
			this.rb.velocity = headingDirection;
		}
	}

	public void AttackTo(Damageable target)
    {
		this.Attack(target);
	}

	protected override void Die()
	{
		if (reward)
        {
			float rand = Random.Range(0f, 1f);
			if (rand <= this.dropRate)
			{
				GameObject obj = Instantiate(reward, transform.position, transform.rotation);
				obj.transform.position = transform.position;
			}
		}
		Destroy(gameObject);
	}

	public override void GetDamaged(float value)
	{
		this.healthBar.UpdateHealth(-value);
	}

	// Basic attack, deal damage on touch
	protected override void Attack(Damageable target)
	{
		if (this.moveAble)
		{
			Vector3 direction = (target.transform.position - transform.position).normalized;
			Vector2 headingDirection = new Vector2(direction.x * speed*2, direction.y * speed*2);
			this.rb.velocity = headingDirection;
		}
	}

	protected virtual void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Damageable target = collision.gameObject.GetComponent<Damageable>();
			
			if (Time.time > this.attackRate + this.lastAttack)
			{
				Vector3 playerPosition = target.transform.position;
				Vector3 direction = (playerPosition - transform.position).normalized;

				// Add force to player
				target.GetComponent<Rigidbody2D>().AddForce(direction * this.pushForce);

				target.GetDamaged(this.damage);

				// Print damage
				GameManager.instance.ShowText((-this.damage).ToString(), 100, Color.red, collision.transform.position + new Vector3(0.5f, 1.75f, 0), Vector3.up, 2.0f);

				this.lastAttack = Time.time;
			}
		}
	}
}
