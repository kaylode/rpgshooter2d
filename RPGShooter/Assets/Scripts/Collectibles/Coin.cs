using UnityEngine;

public class Coin : Collectible
{
    const string COLLECTED_ANIM = "onCollected";

    protected Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void OnCollect()
    {
        this.boxCollider.enabled = false;
        animator.SetTrigger(COLLECTED_ANIM);
        SoundManager.instance.PlaySound("Coin");
        GameManager.instance.ShowText("+1 coin", 100, Color.yellow, transform.position + new Vector3(0.5f, 1.75f, 0), Vector3.up, 1.5f);
        GameManager.instance.coin++;
        Destroy(gameObject, 1f);
    }
}
