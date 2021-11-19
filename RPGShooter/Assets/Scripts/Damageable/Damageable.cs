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

    public virtual float GetHealth()
    {
        return this.healthBar.GetHealth();
    }
    public virtual float GetMaxHealth()
    {
        return this.maxHealth;
    }
}
