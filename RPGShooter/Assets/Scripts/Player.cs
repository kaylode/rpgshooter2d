using UnityEngine;
using System.Collections;

public class Player : Character
{
    [SerializeField]
    private int startingMoney;
    public static int Money;

    private Vector2 movement;
    private Weapon weapon;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject upgradeMenu;
    public delegate void UpgradeMenuCallback(bool active);
    public UpgradeMenuCallback onToggleUpgradeMenu;

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        if (statusIndicator == null)
        {
            Debug.LogError("No status indicator referenced on Player");
        }
        else
        {
            statusIndicator.SetHealth((int)health, (int)maxHealth);
        }
        this.onToggleUpgradeMenu += OnUpgradeMenuToggle;
        base.Start();
        this.weapon = GetComponentInChildren<Weapon>();
        Money = startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.weapon.UpdatePosition(mousePosition);
        this.UpdatePlayerRotation(mousePosition);
        this.UpdateStatusIndicator(mousePosition);
        if (Input.GetKeyDown(KeyCode.U))
        {
            ToggleUpgradeMenu();
        }
    }
    private void ToggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
        onToggleUpgradeMenu.Invoke(upgradeMenu.activeSelf);
    }
    void OnUpgradeMenuToggle(bool active)
    {
        Weapon _weapon = GetComponentInChildren<Weapon>();
        if (_weapon != null)
        {
            _weapon.enabled = !active;
        }
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
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void UpdateStatusIndicator(Vector2 mousePosition)
    {
        Vector2 playerPos = rb.transform.position;
        Vector2 lookDirection = mousePosition - playerPos;

        if (lookDirection.x > 0)
        {
            statusIndicator.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            statusIndicator.transform.localEulerAngles = new Vector3(0, 180, 0);
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
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
        return;
    }

}

