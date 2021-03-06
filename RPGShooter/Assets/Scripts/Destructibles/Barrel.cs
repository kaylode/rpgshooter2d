using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Destructible
{
    const string TAG = "Barrel";
    const string COLLECTED_ANIM = "onDestroyed";

    public float damage = 70;

    private List<Damageable> nearbyDamageableObjects = new List<Damageable>();
    protected Animator animator;

    protected override void Start()
    {
        base.Start();
        this.animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (this.healthBar.GetHealth() <= 0f)
        {
            this.OnDestroyed();
        } 
    }

    protected override void OnDestroyed()
    {
        this.animator.SetTrigger(COLLECTED_ANIM);
        SoundManager.instance.PlaySound("Explosion");
        this.DamageNearby();
        Destroy(gameObject, 1f);
    }

    protected void DamageNearby()
    {
        foreach (Damageable obj in this.nearbyDamageableObjects)
        {
            obj.GetDamaged(this.damage);
        }
    }

    public override void GetDamaged(float value)
    {
        this.healthBar.UpdateHealth(-value);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>())
        {
            nearbyDamageableObjects.Add(collision.gameObject.GetComponent<Damageable>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>())
        {
            this.nearbyDamageableObjects.Remove(collision.gameObject.GetComponent<Damageable>());   
        }
    }
    
}
