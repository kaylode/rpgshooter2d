using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float damage = 20f;
	public GameObject hitEffect;

	void Start() {}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "Wall")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 1f);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Enemy")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 1f);
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
		{
			Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
		}

	}

}
