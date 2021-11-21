using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected bool collected=false;
    protected BoxCollider2D boxCollider;
    protected Sprite sprite;

    protected virtual void Start() 
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
    protected virtual void Update() { }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            this.OnCollect();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            this.OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        this.collected = true;
    }

    public Sprite GetSprite()
    {
        return this.sprite;
    }
}
