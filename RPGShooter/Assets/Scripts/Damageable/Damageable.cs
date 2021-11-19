using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    protected HealthBar healthBar = new HealthBar();

    protected virtual void Start() 
    {
        healthBar.Initialize(maxHealth);
    }
    protected virtual void Update() { }
    public virtual void GetDamaged(float value) 
    {
        this.healthBar.UpdateHealth(-value);
    }
    public virtual void RestoreHealth(float value)
    {
        this.healthBar.UpdateHealth(value);
    }

    public virtual float GetHealth()
    {
        return this.healthBar.GetHealth();
    }
    public virtual float GetMaxHealth()
    {
        return this.maxHealth;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {

    }
}
