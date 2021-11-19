using UnityEngine;

public class GoldChest : Chest
{
    public int amount;
    const string COLLECTED_ANIM = "onCollected";

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            animator.SetTrigger(COLLECTED_ANIM);
            string text = "+" + amount.ToString() + " coin";
            GameManager.instance.ShowText(text, 100, Color.yellow, transform.position + new Vector3(0.5f, 1.75f, 0), Vector3.up, 2.0f);
            GameManager.instance.coin += amount;
        }
    }
}
