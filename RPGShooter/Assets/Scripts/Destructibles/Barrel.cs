using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityFunction;

public class Barrel : Destructible
{
    const string TAG = "Barrel";
    const string COLLECTED_ANIM = "onDestroyed";

    List<GameObject> nearObjects = new List<GameObject>();
    protected Animator animator;

    protected override void Start()
    {
        base.Start();
        this.animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (this.health <= 0f)
        {
            this.OnDestroyed();
        } 
    }

    protected override void OnDestroyed()
    {
        this.animator.SetTrigger(COLLECTED_ANIM);
        Destroy(gameObject, 1f);
    }

    public override void GetDamaged(float value)
    {
        this.health -= value;
        Debug.Log(TAG + " " + this.health.ToString());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>())
        {
            nearObjects.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>())
        {
            this.nearObjects.Remove(collision.gameObject);   
        }
    }
    
}
