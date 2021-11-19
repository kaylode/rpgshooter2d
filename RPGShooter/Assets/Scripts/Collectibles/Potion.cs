using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Collectible
{
    float value = 25f;
    const string COLLECTED_ANIM = "onCollected";

    protected Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().RestoreHealth(value);
            this.OnCollect();
        }
    }

    protected override void OnCollect()
    {
        this.boxCollider.enabled = false;
        animator.SetTrigger(COLLECTED_ANIM);
        string text = "+" + value.ToString() + " hp";
        GameManager.instance.ShowText(text, 100, Color.magenta, transform.position + new Vector3(0.5f, 1.75f, 0), Vector3.up, 1.5f);
    
        Destroy(gameObject, 1f);
    }
}
