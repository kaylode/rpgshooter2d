﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public Animator animator;
	public Rigidbody2D rb;
	public Camera cam;
	public Vector2 movement;

	public float speed = 3f;
	public float health = 100f;
	public int scoreForTakingAHit = -10;

	//private HealthBar healthBar;
	private Weapon weapon;
	private Vector2 mousePosition;
	private SpriteRenderer spriteRenderer;


	void Start()
	{
		//healthBar = GetComponentInChildren<HealthBar>();
		//healthBar.Initialize(health);
		weapon = GetComponentInChildren<Weapon>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
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
}
