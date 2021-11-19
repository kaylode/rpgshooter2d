using UnityEngine;
using System.Collections;

public class Zombie : Enemy
{
	const string TAG = "Zombie";
	
	protected override void Start()
	{
		base.Start();
	}

	public override void Attack(Damageable target)
	{
		if (Time.time > this.attackRate + this.lastAttack)
		{
			Vector3 playerPosition = target.transform.position;
			Vector3 direction = (playerPosition - transform.position).normalized;
			Vector2 headingDirection = new Vector2(direction.x * this.speed * 1.5f, direction.y * this.speed * 1.5f);
			this.rb.velocity = headingDirection;
			this.lastAttack = Time.time;
		}
	}

}
