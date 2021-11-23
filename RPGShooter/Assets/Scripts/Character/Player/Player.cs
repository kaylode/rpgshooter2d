using UnityEngine;
using System.Collections;

public class Player : Character
{
	const string TAG = "Player";
	const string DEATH_ANIM = "onDeath";

	private Vector2 movement;
	private Weapon weapon;

	public UI_Inventory uiInventory;

	public static Inventory inventory;
	public static Player instance;

	// UI
	public GameObject gameOverUI;

	private void Awake()
	{
		if (Player.instance != null)
		{
			Destroy(gameObject);
		}
		instance = this;

		inventory = new Inventory();
		uiInventory.SetInventory(inventory);
		uiInventory.Hidden();
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
		if (this.moveAble)
		{
			this.Move();
			this.SwitchWeapon();
		}
	}

	private void UpdatePlayerRotation(Vector2 mousePosition)
	{
		Vector2 playerPos = rb.transform.position;
		Vector2 lookDirection = mousePosition - playerPos;

		if (lookDirection.x > 0)
		{
			this.transform.localEulerAngles = new Vector3(0, 0, 0);
		}
		else
		{
			this.transform.localEulerAngles = new Vector3(0, 180, 0);
		}
	}

	public void EquipWeapon(Weapon _weapon)
	{
		if (this.weapon != null && !object.ReferenceEquals(this.weapon, _weapon))
		{
			this.weapon.gameObject.SetActive(false);
		}

		this.weapon = _weapon;
		this.weapon.gameObject.SetActive(true);
		_weapon.transform.parent = this.transform;
	}

	public void AddItemToInventory(Collectible item)
	{
		Player.inventory.AddItem(item);
		this.uiInventory.SetInventory(Player.inventory);
	}

	protected override void Move()
	{
		this.rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
	}

	protected override void Die()
	{
		this.animator.SetTrigger(DEATH_ANIM);
        instance.GetComponent<Collider2D>().enabled = false;
		GameManager.instance.FreezeAllMovement();
        gameOverUI.SetActive(true);
	}

	protected void SwitchWeapon()
	{
		Collectible item = null;
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			item = Player.inventory.GetItem(0);
			this.uiInventory.Show();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			item = Player.inventory.GetItem(1);
			this.uiInventory.Show();
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			item = Player.inventory.GetItem(2);
			this.uiInventory.Show();
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			item = Player.inventory.GetItem(3);
			this.uiInventory.Show();
		}

		if (item != null)
			this.EquipWeapon((Weapon)item);
	}
}
