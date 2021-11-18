using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected bool collected=false;
    protected virtual void Start() { }
    protected virtual void Update() { }

    protected void OnCollisionEnter2D(Collision2D collision)
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
}
