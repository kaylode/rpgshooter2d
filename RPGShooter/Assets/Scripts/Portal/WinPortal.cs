using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPortal : Collidable
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
        GameManager.instance.WinScene();
    }
}
