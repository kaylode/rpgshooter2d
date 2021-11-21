using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NPC : Collidable
{
    public Dialog dialog;
    protected bool interacble = false;
    private FloatingText guidanceText;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            guidanceText = GameManager.instance.ShowText("Press Space to interact", 100, Color.white, transform.position + new Vector3(0f, 1.75f, 0), Vector3.zero, 0);
            this.interacble = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.interacble = false;
            guidanceText.Hide();
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            guidanceText = GameManager.instance.ShowText("Press Space to interact", 100, Color.white, transform.position + new Vector3(0f, 1.75f, 0), Vector3.zero, 0);
            this.interacble = true;
        }
    }

    protected override void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.interacble = false;
            guidanceText.Hide();
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
