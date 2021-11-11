using UnityEngine;
using System.Collections;

public class Player : Character
{
	private Vector2 movement;
	private Weapon weapon;

	void Start()
	{
		base.Start();
		this.weapon = GetComponentInChildren<Weapon>();
	}

	// Update is called once per frame
	void Update()
	{
		this.movement.x = Input.GetAxisRaw("Horizontal");
		this.movement.y = Input.GetAxisRaw("Vertical");
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.weapon.UpdatePosition(mousePosition);
		this.UpdatePlayerRotation(mousePosition);
	}

    private void FixedUpdate()
    {
		this.Move();
	}

	private void UpdatePlayerRotation(Vector2 mousePosition)
    {
		Vector2 playerPos = rb.transform.position;
		Vector2 lookDirection = mousePosition - playerPos;
		
		if (lookDirection.x > 0)
		{
			this.transform.eulerAngles = new Vector3(0,0,0);
		}
		else
		{
			this.transform.eulerAngles = new Vector3(0,180,0);
		}
	}

	/*
	protected void equipWeapon(Weapon _weapon)
    {
		this.weapon = _weapon;
		_weapon.transform.parent = this.transform;
	}
	*/

	protected override void Move()
	{
		this.rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
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
