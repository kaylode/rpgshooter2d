using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float damage;
	public GameObject hitEffect = null;

	protected void DealDamage(Damageable target)
    {
		target.GetDamaged(this.damage);
	}

	private void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);
		}

		else if (collision.gameObject.tag == "Wall")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 1f);
			Destroy(gameObject);
		}

		else if (collision.gameObject.GetComponent<Damageable>())
		{
			
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 1f);
			DealDamage(collision.gameObject.GetComponent<Damageable>());
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
