using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable
{

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Change scene
            Teleport();
        }
    }

    private void Teleport()
    {
        Debug.Log("Teleported");
    }
}
