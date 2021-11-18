using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    private GameObject player;

    void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        return;
    }

    /*
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Bullet") {
			BulletController bullet = collision.gameObject.GetComponent<BulletController>();
			Debug.Log("Health is: " + health);
			health -= bullet.damage;
			healthBar.setHealth(health);
			Destroy (collision.gameObject);
		}
	}
	*/
}
