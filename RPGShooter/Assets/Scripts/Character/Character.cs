using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float shield = 0f;
    public float speed = 3f;
    public float damage = 3f;

    protected Animator animator;
    protected Rigidbody2D rb;

    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Die();

    protected virtual void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }


}