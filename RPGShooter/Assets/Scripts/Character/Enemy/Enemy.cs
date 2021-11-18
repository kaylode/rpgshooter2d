using UnityEngine;
using System.Collections;

public class Enemy : Character 
{
	const string TAG = "Zombie";
	private GameObject player;

	protected override void Start()
	{
		base.Start();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();
	}

	protected override void Move()
	{
		Vector3 playerPosition = player.transform.position;
		Vector3 direction = (playerPosition - transform.position).normalized;
		Vector2 headingDirection = new Vector2(direction.x * speed, direction.y * speed);
		rb.velocity = headingDirection;
	}

	protected override void Attack()
	{
		return;
	}

	protected override void Die()
	{
		Destroy(gameObject);
	}

	public override void GetDamaged(float value)
	{
		this.health -= value;
		Debug.Log(TAG + " " + this.health.ToString());
	}
}
