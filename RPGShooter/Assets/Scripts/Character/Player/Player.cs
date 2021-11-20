using UnityEngine;
using System.Collections;

public class Player : Character
{
	const string TAG = "Player";
	const string DEATH_ANIM = "onDeath";

	private Vector2 movement;
	private Weapon weapon;

	public UI_Inventory uiInventory;
	private Inventory inventory;

	public static Player instance;

	private void Awake()
	{
		if (Player.instance != null)
		{
			Destroy(gameObject);
		}
		instance = this;

		inventory = new Inventory();
		uiInventory.SetInventory(inventory);
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
	}

    private void FixedUpdate()
    {
		if (this.moveAble)
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
			this.weapon.gameObject.SetActive(false);
		}
		this.weapon = _weapon;
		_weapon.transform.parent = this.transform;
	}

	public void AddItemToInventory(Collectible item)
    {
		this.inventory.AddItem(item);
		this.uiInventory.SetInventory(this.inventory);
	}

	protected override void Move()
	{
		this.rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
	}

	protected override void Die()
	{
		this.animator.SetTrigger(DEATH_ANIM);

		//Wait for 2 seconds
		new WaitForSecondsRealtime(6);

		GameManager.instance.LoadScene(2);
	}
}
