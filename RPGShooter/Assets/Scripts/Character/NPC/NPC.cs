using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NPC : Collidable
{
    public Dialog dialog;
    protected bool interacble = false;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.interacble = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.interacble = false;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.interacble = true;
        }
    }

    protected override void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.interacble = false;
        }
    }

    protected void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (this.interacble)
            {
                DialogManager.instance.ShowDialog(dialog);
            }
        }
    }
}
