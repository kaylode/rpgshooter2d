using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
	public float pushForce = 5000;

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Enemy")
		{
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);
		}

		else if (collision.gameObject.tag == "Wall")
		{
			if (hitEffect != null)
            {
				GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
				Destroy(effect, 1f);
            }
			Destroy(gameObject);
		}

		else if (collision.gameObject.GetComponent<Damageable>())
		{
			if (hitEffect != null)
			{
				GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
				Destroy(effect, 1f);
			}

			Vector2 playerPosition = collision.transform.position;
			Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

			// Add force to target
			collision.transform.GetComponent<Rigidbody2D>().AddRelativeForce(direction * this.pushForce);
			
			DealDamage(collision.gameObject.GetComponent<Damageable>());

			// Print damage
			GameManager.instance.ShowText((-this.damage).ToString(), 100, Color.red, transform.position + new Vector3(0.5f, 1.75f, 0), Vector3.up, 2.0f);

			Destroy(gameObject);
		}

		else if (collision.gameObject.tag == "Destructible")
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		else
		{
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);
		}

	}
}
