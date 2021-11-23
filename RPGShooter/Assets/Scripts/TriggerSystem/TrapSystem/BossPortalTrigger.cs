using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : TriggerZone
{
    public Portal portal;
    public Boss boss;

    protected override void Start()
    {
        triggerPoint.OnPlayerEnterTrigger += AssignBossTrigger;
    }
    
    protected void AssignBossTrigger(object sender, System.EventArgs e)
    {
        string bossName = this.boss.name;
        Transform bossTransform = gameObject.transform.Find(bossName);
        Boss bossObject = bossTransform.gameObject.GetComponent<Boss>();
        bossObject.OnDeathTrigger += SpawnPortal;
    }

    private void SpawnPortal(object sender, System.EventArgs e)
    {
        Instantiate(portal, transform.position, transform.rotation);
    }
}
