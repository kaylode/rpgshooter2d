using UnityEngine;
using System.Collections;

public class Player : Character
{
	private Vector2 movement;
	private Weapon weapon;
	private Vector2 mousePosition;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		base.Start();
		weapon = GetComponentInChildren<Weapon>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		weapon.UpdatePosition(mousePosition);
		UpdatePlayerRotation(mousePosition);
	}

    private void FixedUpdate()
    {
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
	}

	private void UpdatePlayerRotation(Vector2 mousePosition)
    {
		Vector2 playerPos = rb.transform.position;
		Vector2 lookDirection = mousePosition - playerPos;
		
		if (lookDirection.x > 0)
		{
			transform.eulerAngles = new Vector3(0,0,0);
		}
		else
		{
			transform.eulerAngles = new Vector3(0,180,0);
		}
	}

	protected override void Move()
	{
		return;
	}

	protected override void Attack()
	{
		return;
	}

	protected override void Die()
	{
		return;
	}
}
