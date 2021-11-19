using UnityEngine;
using System.Collections;

public class Player : Character
{
	const string TAG = "Player";
	private Vector2 movement;
	private Weapon weapon;

	public static Player instance;
	private void Awake()
	{
		if (Player.instance != null)
		{
			Destroy(gameObject);
		}
		instance = this;
	}


	protected override void Start()
	{
		base.Start();
		this.weapon = GetComponentInChildren<Weapon>();
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
		this.movement.x = Input.GetAxisRaw("Horizontal");
		this.movement.y = Input.GetAxisRaw("Vertical");
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.UpdatePlayerRotation(mousePosition);
		// Debug.Log(TAG + this.GetHealth().ToString());
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
			this.transform.localEulerAngles = new Vector3(0,0,0);
		}
		else
		{
			this.transform.localEulerAngles = new Vector3(0,180,0);
		}
	}

	public void EquipWeapon(Weapon _weapon)
    {
		if (this.weapon != null)
        {
			Destroy(this.weapon.gameObject);
		}
		this.weapon = _weapon;
		_weapon.transform.parent = this.transform;
	}

	protected override void Move()
	{
		this.rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
	}

	protected override void Die()
	{
		this.animator.Play("Die");

		//Wait for 2 seconds
		new WaitForSecondsRealtime(6);

		GameManager.instance.LoadScene(2);
	}
}
