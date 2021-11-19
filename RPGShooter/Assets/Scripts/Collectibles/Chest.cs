using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
    public Collectible reward;

    const string COLLECTED_ANIM = "onCollected";

    protected Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            animator.SetTrigger(COLLECTED_ANIM);
            GameManager.instance.ShowText("+8 Coin !", 100, Color.yellow, transform.position + new Vector3(0.5f, 1.75f, 0), Vector3.up, 2.0f);
        }
    }
}
