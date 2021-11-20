using UnityEngine;
using System.Collections;

public abstract class Character : Damageable
{
    public float shield;
    public float speed;
    public float damage;

    protected Animator animator;
    protected Rigidbody2D rb;

    protected bool moveAble = true;

    protected virtual void Move() { }
    protected virtual void Attack(Damageable target) { }
    protected virtual void Die() { }
    protected override void Update()
    {
        base.Update();
        if (this.healthBar.GetHealth() <= 0f)
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

    public virtual Vector3 GetPosition()
    {
        return transform.position;
    }

    public void FreezeMovement()
    {
        this.moveAble = false;
    }
    public void UnFreezeMovement()
    {
        this.moveAble = true;
    }
}