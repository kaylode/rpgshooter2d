using System;
using UnityEngine;

public class Boss : Enemy
{
    public event EventHandler OnDeathTrigger;
	const string DEATH_ANIM = "onDeath";

	public float shootingForce = 20f;
	public GameObject bulletPrefab;
	
	protected override void Start()
    {
		base.Start();
		SoundManager.instance.PlaySong("BattleTheme");
    }

	// Trigger the trigger zone
	protected void InvokeTrigger()
	{
		EventHandler handler = OnDeathTrigger;
		if (handler != null)
			handler(this, EventArgs.Empty);

	}

    protected override void Die()
	{
		this.animator.SetTrigger(DEATH_ANIM);
		if (reward)
		{
			float rand = UnityEngine.Random.Range(0f, 1f);
			if (rand <= this.dropRate)
			{
				GameObject obj = Instantiate(reward, transform.position, transform.rotation);
				obj.transform.position = transform.position;
			}	
		}
		SoundManager.instance.StopSound("BattleTheme");

		InvokeTrigger();
		Destroy(gameObject);
	}

	protected override void Attack(Damageable target)
    {
		if (Time.time > this.attackRate + this.lastAttack)
		{
			GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
			Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

			Vector3 direction = (target.transform.position - transform.position).normalized;

			rb.AddForce(shootingForce * direction, ForceMode2D.Impulse);
			Destroy(newBullet, 5f);
			lastAttack = Time.time;
		}
	}
}
