using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Boss
{
    public float[] shootingForces;
    public GameObject[] bulletPrefabs;
	PHRASE phrase;
	PHRASE lastPhrase;
	bool ableToAttack=true;

	const string DEATH_ANIM = "onDeath";
	const string PHRASE_ANIM = "onPhrase";
	const string TELEPORT_ANIM = "onTeleport";
	const string ATTACK_ANIM = "onAttack";

	public enum PHRASE
    {
		ONE,
		TWO,
		THREE,
		DEATH
	}

	public float[] HEALTH_PHRASE = { 0.6f, 0.15f };

	protected void Awake()
    {
		phrase = PHRASE.ONE;
		lastPhrase = PHRASE.ONE;

	}

	protected override void Start()
	{
		base.Start();
	}

	protected void PhraseAttack(Damageable target)
    {
		if (Time.time > this.attackRate + this.lastAttack && ableToAttack)
		{
			this.animator.SetTrigger(ATTACK_ANIM);

			Vector2 direction = (target.transform.position - transform.position);
			direction += new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f));

			direction = direction.normalized;
			GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

			float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			if (n < 0) n += 360;

			newBullet.transform.eulerAngles = new Vector3(0, 0, n);
			newBullet.GetComponent<Rigidbody2D>().AddForce(shootingForce * direction, ForceMode2D.Impulse);
			Destroy(newBullet, 5f);
			lastAttack = Time.time;
		}
	}

	protected override void Attack(Damageable target)
	{

		phrase = CheckPhrase();
		CheckPhraseTransition();
		
		switch (phrase)
        {
			case PHRASE.ONE:
				this.bulletPrefab = this.bulletPrefabs[0];
				this.shootingForce = this.shootingForces[0];
				PhraseAttack(target);
				break;

			case PHRASE.TWO:
				this.bulletPrefab = this.bulletPrefabs[1];
				this.shootingForce = this.shootingForces[1];
				PhraseAttack(target);
				Teleport();
				break;

			case PHRASE.THREE:
				this.bulletPrefab = this.bulletPrefabs[2];
				this.shootingForce = this.shootingForces[2];
				PhraseAttack(target);
				Teleport();
				break;
			case PHRASE.DEATH:
				break;
		}
	}

    private void Teleport()
    {
		float rand = Random.Range(0, 1f);
		float thresh = -1f;
		if (phrase == PHRASE.TWO)
			thresh = 0.2f;
		else if (phrase == PHRASE.THREE)
			thresh = 0.35f;
			
		if (rand < thresh)
        {
			this.animator.SetTrigger(TELEPORT_ANIM);
		}
    }
	public void RandomTeleport()
	{
		// Random direction
		Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

		// Add force
		this.rb.AddForce(direction * 1000f);
	}

    private void CheckPhraseTransition()
    {
		if (lastPhrase != phrase)
		{
			this.animator.SetTrigger(PHRASE_ANIM);
			lastPhrase = phrase;
		}

	}

    protected PHRASE CheckPhrase()
    {
		float currentHPPercent = this.GetHealth() / this.GetMaxHealth();

		if (currentHPPercent < HEALTH_PHRASE[1])
			return PHRASE.THREE;

		if (currentHPPercent < HEALTH_PHRASE[0])
			return PHRASE.TWO;

		return PHRASE.ONE;
	}

	public override void MoveTo(Vector3 position)
	{
		if (this.moveAble)
		{
			Vector3 direction = (position - transform.position).normalized;
			Vector2 headingDirection = new Vector2(direction.x * speed, direction.y * speed);

			if (headingDirection.x >= 0)
			{
				spriteRenderer.flipX = true;
			}
			else
			{
				spriteRenderer.flipX = false;
			}
			this.rb.velocity = headingDirection;
		}
	}

	protected override void Die()
	{
		this.animator.SetTrigger(DEATH_ANIM);

		float delay = 0f;
		this.phrase = PHRASE.DEATH;

		InvokeTrigger();
		Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
	}
}
