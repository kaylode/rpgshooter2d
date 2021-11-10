using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;

	public float shootingForce = 20f;
	public const float fireRate = 0.3f;

	private float currentTime;
	private bool canShoot = false;

	// Update is called once per frame
	void Update () {

		currentTime += Time.deltaTime;

		if (currentTime > fireRate)
		{
			canShoot = true;
			currentTime = 0f;
		}

		if (canShoot && Input.GetButton("Fire1")) {
			ShootBullet();
			canShoot = false;
		}
	}

	void ShootBullet()
    {
		GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
		rb.AddForce(shootingForce * firePoint.right, ForceMode2D.Impulse);
		Destroy(newBullet, 5f);
	}
}
