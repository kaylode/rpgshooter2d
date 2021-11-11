using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float shield = 0;
    public float speed = 3f;
    public float damage = 3f;

    public Animator animator;
    public Rigidbody2D rb;


    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Die();


}