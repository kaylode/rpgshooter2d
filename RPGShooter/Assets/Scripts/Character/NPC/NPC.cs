using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Collidable
{
    public Dialog dialog;
    public bool interacble = false;

    protected void OnCollisionStay2D(Collision2D collision)
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
