using UnityEngine;
using System.Collections;

public abstract class Character : Damageable
{
    public float maxHealth;
    public float shield;
    public float speed;
    public float damage;

    protected Animator animator;
    protected Rigidbody2D rb;

    protected virtual void Move() { }
    protected virtual void Attack() { }
    protected virtual void Die() { }
    protected override void Update()
    {
        base.Update();
        if (this.health < 0f)
        {
            this.Die();
        }
    }

    protected override void Start()
    {
        base.Start();
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }


}